using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] float jumpForce = 3;
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashDuration = 0.2f;
    [SerializeField] float dashCooldown = 1f;
    [SerializeField] ContactFilter2D groundFilter;
    Vector2 inputDir = Vector2.zero;
    bool jump = false;
    bool isDashing = false;
    bool grounded = false;
    float lastDashTime = 0f; 
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sprite;
    PlayerHealth playerHealth;
    BoxCollider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        playerHealth = GetComponent<PlayerHealth>(); 
    }

    // Update is called once per frame
    void Update()
    {
        grounded = coll.IsTouching(groundFilter);

        if (!isDashing) 
        {
            Vector2 velocity = new Vector2(inputDir.x * speed, rb.velocity.y);
            rb.velocity = velocity;
        }

        if (jump)
        {
            Jump();
        }
    }

    public void SetMoveDir(InputAction.CallbackContext context)
    {
        inputDir = context.ReadValue<Vector2>();
    }

    public void ActiveJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jump = true;
        }
        if (context.performed || context.canceled)
        {
            jump = false;
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.started && !isDashing && Time.time - lastDashTime >= dashCooldown) 
        {
            StartCoroutine(DoDash());
            lastDashTime = Time.time; 
            playerHealth.SetInvulnerable(true); 
        }
    }

    IEnumerator DoDash()
    {
        isDashing = true;
        float startTime = Time.time;

        // Calculate dash direction based on inputDir
        Vector2 dashDirection = inputDir.normalized;
        if (dashDirection == Vector2.zero) // If no input, dash forward based on player's facing direction
        {
            dashDirection = sprite.flipX ? Vector2.left : Vector2.right;
        }

        while (Time.time < startTime + dashDuration)
        {
            rb.velocity = dashDirection * dashSpeed;
            yield return null;
        }

        rb.velocity = Vector2.zero;
        isDashing = false;
        playerHealth.SetInvulnerable(false); // Set player back to vulnerable after the dash
    }

    private void Jump()
    {
        if (grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);


            jump = false;
        }
    }
}

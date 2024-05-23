using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform rotatePoint;
    [SerializeField] Transform firePoint;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float fireRate = 0.1f; 

    private bool isShooting = false;
    private float nextFireTime = 0f;

    void Update()
    {
        if (isShooting && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; 
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isShooting = true;
            Shoot(); 
            nextFireTime = Time.time + fireRate; 
        }
        else if (context.canceled)
        {
            isShooting = false;
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * projectileSpeed; 
        Debug.Log("Projectile instantiated at: " + firePoint.position + " with velocity: " + rb.velocity);
    }

    void FixedUpdate()
    {
        RotateRotatePoint();
    }

    void RotateRotatePoint()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 rotatePointPosition = Camera.main.WorldToScreenPoint(rotatePoint.position);
        Vector2 direction = mousePosition - rotatePointPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotatePoint.rotation = Quaternion.Euler(0, 0, angle); 
    }
}

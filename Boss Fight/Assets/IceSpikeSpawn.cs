using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpikeAttack : StateMachineBehaviour
{
    public GameObject iceSpikePrefab;
    public Transform spawnPoint;
    public float spikeForce = 10f;
    public float spreadAngle = 30f; // Spread angle for the spikes
    public float timeBetweenSpawns = 0.1f; // Time between spawns

    private float lastSpawnTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.transform.childCount > 0)
        {
            spawnPoint = animator.transform.GetChild(0); // Assumes the first child is the spawn point
        }

        lastSpawnTime = Time.time;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Time.time - lastSpawnTime >= timeBetweenSpawns)
        {
            SpawnIceSpike();
            lastSpawnTime = Time.time;
        }
    }

    void SpawnIceSpike()
    {
        if (spawnPoint != null)
        {
            // Randomize angle within the spreadAngle
            Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(-spreadAngle, spreadAngle));

            GameObject iceSpike = Instantiate(iceSpikePrefab, spawnPoint.position, rotation);
            Rigidbody2D rb = iceSpike.GetComponent<Rigidbody2D>();
            rb.AddForce(rotation * Vector2.up * spikeForce, ForceMode2D.Impulse); // Shoot the ice spike upwards
        }
        else
        {
            Debug.LogError("Spawn point is not assigned! Make sure to assign a spawn point in the animator or attach one to the boss GameObject.");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LineofSight : MonoBehaviour

{
    public Transform player; 
    public float detectionRange = 100f;
    //private NavMeshAgent agent;
    public LayerMask obstacleLayer; // Layer mask for objects that block LOS.

    private bool playerInLOS = false;

    private void Start()
    {
        player = GameObject.Find("FirstPersonController").transform; // Replace "Player" with the name of your player GameObject.
        //agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Check if the player is within detection range.
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            // Check LOS between the enemy and the player.
            Vector3 directionToPlayer = player.position - transform.position;
            RaycastHit hit;

            if (Physics.Raycast(transform.position, directionToPlayer, out hit, detectionRange, obstacleLayer))
            {
                if (hit.collider.CompareTag("Player")) // Or check if the hit object belongs to the player layer.
                {
                    playerInLOS = true;
                    print("I_saw_a_player");
                }
                else
                {
                    playerInLOS = false;
                }
            }
        }
        else
        {
            playerInLOS = false;
        }


        if (player != null)
        {
            // Calculate the direction from the enemy to the player.
            Vector3 direction = player.position - transform.position;
            direction.y = 0; // Ensure the enemy does not tilt upwards or downwards.

            if (direction != Vector3.zero)
            {
                // Calculate the rotation angle in degrees.
                float rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

                // Apply the rotation to the enemy.
                transform.rotation = Quaternion.Euler(0, rotationAngle, 0);

                // Set the destination of the NavMeshAgent to the player's position.
                //agent.SetDestination(player.position);

                
            }
        }

    }
}    



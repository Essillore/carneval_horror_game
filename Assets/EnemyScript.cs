using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform target;
    public GameObject player;
    public Animator Clownanim;
    public float playerDistance; // Change variable name to playerDistance
    public float enemySpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FirstPersonController");
        Clownanim = GetComponent<Animator>(); // Get the Animator component from the object
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance between the enemy and the player.
        playerDistance = Vector3.Distance(transform.position, player.transform.position);
        transform.LookAt(target);
        transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
    }

    public void PlayerInSight() // Correct method name to PlayerInSight
    {
        // Check the player's distance and set the animation parameter.
        if (playerDistance <= 20)
        {
            Clownanim.SetBool("SeeingPlayer", true);
        }
        else
        {
            Clownanim.SetBool("SeeingPlayer", false);
        }
    }
}
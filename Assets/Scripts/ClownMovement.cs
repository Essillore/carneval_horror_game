using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardForce = transform.forward * moveSpeed;
        //rb.AddForce(forwardForce);
        Vector3 movement = transform.forward * moveSpeed * Time.deltaTime;
        transform.position += movement;

    }
}

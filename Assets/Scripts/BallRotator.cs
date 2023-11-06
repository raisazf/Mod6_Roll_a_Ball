using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotator : MonoBehaviour
{
    private Rigidbody rb;
    public float rotationSpeed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get the velocity of the Rigidbody
        Vector3 velocity = rb.velocity.normalized;

        if (velocity.magnitude > 0)
        {
            // Calculate the rotation angle based on the velocity direction
            float rotationAngle = Mathf.Atan2(velocity.x, velocity.z) * Mathf.Rad2Deg;

            // Create a Quaternion to represent the rotation
            Quaternion targetRotation = Quaternion.Euler(0f, rotationAngle, 0f);

            // Smoothly rotate the ball towards the rolling direction
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}


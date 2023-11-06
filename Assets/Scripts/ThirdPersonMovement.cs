using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using static UnityEngine.GraphicsBuffer;

public class ThirdPersonMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cameraRig;
    public GameObject rotatingSphere;
    public float jumpForce = 5;

    public float speed = 5f;
    public float jumpHeight = 2f;

    private Vector3 direction;
    private Vector3 rotation;
    private Vector3 velocity;
    private float gravity = -9.81f;
    private bool isRotating = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //transform.Translate(direction * speed * Time.deltaTime);

        Vector3 localDirection = transform.TransformDirection(direction); // make world direction into local direction
        rb.MovePosition(rb.position + (localDirection * speed * Time.deltaTime));
        RotationEffect();

    }

    private void RotationEffect()
    {
        velocity = rb.velocity.normalized;

        if (velocity.magnitude > 0.2f )
        {

            float localDistance = speed * Time.deltaTime;
            float circumference = 2f * Mathf.PI * rotatingSphere.transform.localScale.x;
            float angleDelat = localDistance / circumference * 360;

            Vector3 relativePos = Vector3.forward - rotatingSphere.transform.position;

            rotation = Quaternion.LookRotation(relativePos) * Vector3.right;

            if (isRotating)
            {
                rotatingSphere.transform.Rotate(rotation, angleDelat, Space.Self);
            }
            else
            {
                rotatingSphere.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            }
        }
    }

    public void OnBallMove(InputValue value)
    {

        Vector2 inputVector = value.Get<Vector2>();

        // move in XZ plane
        direction.x = inputVector.x;
        direction.z = inputVector.y;



    }

    public void OnBallJump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flag"))
        {
            isRotating = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Flag"))
        {
            isRotating = true;
        }
    }
}
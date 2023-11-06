using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform rollingBall;

    public float horizontalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        if (rollingBall == null)
            Debug.Log("Camera requires a reference to the ball.");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = rollingBall.position;

        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            float h = horizontalSpeed * Input.GetAxis("Mouse X");

            transform.Rotate(0, h, 0);
        }
        else
            Cursor.lockState = CursorLockMode.None;
    }
}



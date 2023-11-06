using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAttacher : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
            other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
            other.transform.parent = null;
    }

}
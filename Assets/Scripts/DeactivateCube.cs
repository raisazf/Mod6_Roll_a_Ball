using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateCube : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Ball"))
        {
            this.gameObject.SetActive(false);
        }
    }
}

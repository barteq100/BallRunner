using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPad : MonoBehaviour
{
    public Vector3 SpeedToGive;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<BallController>().Rigidbody.AddForce(SpeedToGive, ForceMode.Impulse);
        }
    }
}

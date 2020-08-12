using Assets.Scripts.Save;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    public int Id;
    // Update is called once per frame

    public UnityAction<Checkpoint> OnCheckPointCrossed;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCheckPointCrossed?.Invoke(this);
        }
    }
}

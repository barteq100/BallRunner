using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AutoJumpPad : MonoBehaviour
{
    private bool _isOpen = false;

    private Animator _animator;
    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerAnim(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerAnim(false);
        }
    }

    private void TriggerAnim(bool state)
    {
        _isOpen = state;
        _animator.SetBool("IsOpen", _isOpen);
    }
}

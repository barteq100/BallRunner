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
            TriggerAnim();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerAnim();
        }
    }

    private void TriggerAnim()
    {
        _isOpen = !_isOpen;
        _animator.SetBool("IsOpen", _isOpen);
    }
}

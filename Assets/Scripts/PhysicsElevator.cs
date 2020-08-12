using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsElevator : MonoBehaviour
{
    public Vector3 moveSpeed;
    private Rigidbody _rigidbody;
    private Vector3 wantedMoveSpeed;
    private float waitTime = 0.5f;
    private float timePassed = 0f;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = moveSpeed;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            wantedMoveSpeed = moveSpeed * -1;
            moveSpeed = Vector3.zero;
            timePassed = 0f;
            StartCoroutine(WaitAndChangeDirection());
        }
    }

    IEnumerator WaitAndChangeDirection()
    {
        while (timePassed < waitTime)
        {
            timePassed += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        moveSpeed = wantedMoveSpeed;
        StopCoroutine(WaitAndChangeDirection());
    }
}

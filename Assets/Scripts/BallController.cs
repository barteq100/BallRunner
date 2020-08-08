using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody Rigidbody => _rigidbody;
    private Rigidbody _rigidbody;

    public float speed = 3f;
    private bool _isOnGround = true;

    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Controlls();
    }

    void Controlls()
    {
        if (_isOnGround)
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            var force = new Vector3(horizontal, 0, vertical);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody.AddForce(new Vector3(0, 3f, 0), ForceMode.Impulse);
                _isOnGround = false;
            }

            _rigidbody.AddForce(force * speed, ForceMode.Force);
        }

    }

    private void OnCollisionStay(Collision other)
    {
        _isOnGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _isOnGround = false;
    }
}



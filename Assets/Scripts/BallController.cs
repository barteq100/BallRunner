using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody Rigidbody => _rigidbody;
    private Rigidbody _rigidbody;

    private float speed = 6f;
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
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var force = new Vector3(horizontal, 0, vertical);
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _rigidbody.AddForce(new Vector3(0, 3f, 0), ForceMode.Impulse);
            _isOnGround = false;
        }

        _rigidbody.AddForce(force * speed, ForceMode.Force);
    }

    private void OnCollisionStay(Collision other)
    {
        _isOnGround = true;
    }
}



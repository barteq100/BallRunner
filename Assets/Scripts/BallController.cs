using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody Rigidbody => _rigidbody;
    private Rigidbody _rigidbody;

    public float speed = 3f;
    public float jumpForce = 5f;
    private bool _isOnGround = true;
    public Vector3 cachedForce = Vector3.zero;
    public bool cachingForce = false;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Controlls();
        TryRemoveCachedFroce();
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
                TryJump(new Vector3(horizontal, jumpForce, vertical));
            }
            _rigidbody.AddForce(force * speed, ForceMode.Force);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Track"))
        {
            TryJump(cachedForce);
           
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Track"))
        {
            cachedForce = Vector3.zero;
            cachingForce = true;
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Track"))
        {
            cachingForce = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (cachingForce && Input.GetKey(KeyCode.Space))
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            var force = new Vector3(horizontal, jumpForce, vertical);
            cachedForce = force;
        }
    }


    void TryJump(Vector3 force)
    {
        if (force.sqrMagnitude <= 0f) return;
        _rigidbody.AddForce(force, ForceMode.Impulse);
        _isOnGround = false;
        cachedForce = Vector3.zero;
    }

    void TryRemoveCachedFroce()
    {
        if(!cachingForce && Input.GetKeyUp(KeyCode.Space))
        {
            cachedForce = Vector3.zero;
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownGravity : MonoBehaviour {

    public bool _down = true;
    public bool _isGrounded = false;

    private Rigidbody rigidbody;
    private Vector3 velocity;
    private Vector3 gravity;

    // Use this for initialization
    void Start() {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        velocity = Vector3.zero;
        gravity = Physics.gravity;
        if(_down)
        {
            gravity *= -1F;
        }
    }

    // Update is called once per frame
    void Update() {
        if(_isGrounded)
        {
            velocity.y = 0F;
        }
        else
        {
            velocity -= gravity * Time.deltaTime;
        }
    }

    void FixedUpdate() {
        rigidbody.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    public void Move(Vector3 v, float speed) {
        velocity.x = v.x * speed;
        velocity.z = v.z * speed;
        transform.LookAt(transform.position + velocity);
    }

    public void Jump(float power) {
        _isGrounded = false;
        velocity.y = _down ? power : -power;
    }

    void OnCollisionEnter() {
        _isGrounded = true;
    }

    void OnCollisionExit() {
        _isGrounded = false;
    }
}

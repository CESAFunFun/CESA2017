using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DownGravity : MonoBehaviour {

    public bool _isGrounded = false;
    public bool _downGravity = true;

    private Rigidbody rigidbody;
    private Vector3 velocity;
    private Vector3 gravity;


	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        rigidbody.useGravity = false;
        velocity = Vector3.zero;
        gravity = -Physics.gravity;
        if(_downGravity)
        {
            gravity *= -1F;
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -3F;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            velocity.x = +3F;
        }
        else
        {
            velocity.x = 0F;
        }

        if (_isGrounded)
        {
            velocity.y = 0F;
        }
        else
        {
            rigidbody.AddForce(gravity);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isGrounded = false;
            Vector3 upVec = _downGravity ? Vector3.up : Vector3.down;
            rigidbody.AddForce(upVec * 5F * 100F);
            
        }
    }

    void FixedUpdate() {
        rigidbody.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    void Move(Vector3 v, float speed) {
        velocity.x = v.x * speed;
        velocity.z = v.z * speed;
        transform.LookAt(transform.position + new Vector3(velocity.x, 0F, velocity.z));
    }

    void OnCollisionEnter(Collision other) {
        _isGrounded = true;
    }

    void OnCollisionExit(Collision other) {
        _isGrounded = false;
    }
}

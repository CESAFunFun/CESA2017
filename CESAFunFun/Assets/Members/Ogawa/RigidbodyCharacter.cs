using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyCharacter : MonoBehaviour {

    public bool _isGrounded;

    private Rigidbody rigidbody;
    private Vector3 velocity;

    // Use this for initialization
    void Start() {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        velocity = Vector3.zero;
        _isGrounded = false;
    }

    // Update is called once per frame
    void Update() {
    }

    void FixedUpdate() {
        // Rigidbodyの機能で座標の更新を行う
        rigidbody.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    public void Move(Vector3 v, float speed) {
        // XXX:Ｙ軸が意図的に排除されている
        velocity.x = v.x * speed;
        velocity.z = v.z * speed;
        transform.LookAt(transform.position + velocity);
    }

    public void Jump(float power) {
        if (_isGrounded)
        {
            _isGrounded = false;
            rigidbody.AddForce(transform.up * power * 100F);
        }
    }

    void OnCollisionEnter(Collision col) {
        _isGrounded = true;
    }
}

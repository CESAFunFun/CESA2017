using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyShot : MonoBehaviour {

    [SerializeField]
    private Collider collider;
    [SerializeField]
    private Vector3 direction;

    private Rigidbody rigidbody;
    private bool isShot;
    private bool isGrounded;
    private bool groundCollider;

    // Use this for initialization
    void Start() {
        rigidbody = GetComponent<Rigidbody>();
        isShot = false;
        isGrounded = false;
        groundCollider = false;
    }

    // Update is called once per frame
    void Update() {
        // Colliderが接地していない場合はレイを飛ばす
        if (!groundCollider)
        {
            if (Physics.Linecast(collider.transform.position, (collider.transform.position - transform.up)))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
            Debug.DrawLine(transform.position, transform.position - transform.up * 0.5F, Color.red);
        }

        // 入力による射出処理
        if (Input.GetButtonDown("Fire4"))
        {
            if (!isShot)
            {
                isShot = true;
                collider.isTrigger = false;
                rigidbody.isKinematic = false;
                rigidbody.velocity = direction;

                if (transform.parent)
                {
                    transform.parent = null;
                }
            }
        }

        // 接地していなければ重力処理を行う
        if (!groundCollider && !isGrounded)
        {
            transform.Translate(new Vector3(0F, Physics.gravity.y, 0F) * Time.deltaTime);
        }

        // 接地しているときの処理
        if (groundCollider && isGrounded)
        {
            if (!isShot) collider.isTrigger = true;
            rigidbody.isKinematic = true;
        }
    }

    void OnCollisionEnter(Collision col) {
        // Colliderが接地しているか判定
        if (Physics.Linecast(collider.transform.position, (collider.transform.position - transform.up)))
        {
            groundCollider = true;
        }
    }

    void OnCollisionExit() {
        // Colliderは接地していない
        groundCollider = false;
    }
}

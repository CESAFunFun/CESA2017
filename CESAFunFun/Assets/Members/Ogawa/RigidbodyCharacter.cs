using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyCharacter : MonoBehaviour {

    public bool _isGrounded = false;
    public bool _objected = false;

    private Rigidbody rigidbody;
    private Vector3 velocity;

    public float moveSpeed = 1F;
    public float jumpPower = 1F;

    void Start() {
        // アタッチされているRigidbodyを取得
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        velocity = Vector3.zero;
    }

    void Update() {
        // TODO : 自前の重力処理が記載されます
    }

    void FixedUpdate() {
        // Rigidbodyでの位置座標を更新
        rigidbody.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    public void Move(Vector3 v, float speed) {
        // XXX:Ｙ軸を意図的に排除している
        velocity.x = v.x * speed;
        velocity.z = v.z * speed;
        transform.LookAt(transform.position + velocity);
    }

    public void Jump(float power) {
        // 接地しているときのみ跳躍
        if (_isGrounded)
        {
            _isGrounded = false;
            rigidbody.AddForce(transform.up * power * 100F);
        }
    }

    void OnCollisionEnter(Collision other) {
        // 接地判定のフラグを変更
        _isGrounded = true;
        // タグ"Child"のみオブジェクト化する
        if (tag == "Child")
        {
            rigidbody.isKinematic = true;
            if (!_objected)
            {
                GetComponent<BoxCollider>().isTrigger = true;
            }
        }
    }
}

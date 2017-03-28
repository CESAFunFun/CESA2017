using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyCharacter : MonoBehaviour {

    [SerializeField]
    private bool downGravity = true;

    private Rigidbody rigidbody;
    private Vector3 velocity;
    private Vector3 gravity;
    [SerializeField]
    private bool groundCollider;
    [SerializeField]
    private bool isGrounded;

    void Start() {
        // Rigidbodyの設定(重力・回転の無効化)
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        // 移動速度の初期化
        velocity = Vector3.zero;
        // 接地関係のフラグ
        groundCollider = false;
        isGrounded = false;

        // 自身の重力を設定
        gravity = Physics.gravity;
        // 重力方向の決定
        if (downGravity)
        {
            gravity *= -1F;
        }
    }

    void Update() {
        // Colliderが接地していなければレイを飛ばして判定
        if (!groundCollider)
        {
            if (Physics.Linecast(transform.position, transform.position - gravity.normalized))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }

            // レイがどの方向に飛んでいるか描画チェック
            Debug.DrawLine(transform.position, transform.position - gravity.normalized, Color.red);
        }

        // 接地していなければ重力処理を行う
        if (!groundCollider && !isGrounded)
        {
            velocity -= gravity * Time.deltaTime;
        }
        if (groundCollider)
        {
            velocity.y = 0F;
        }
    }

    void FixedUpdate() {
        // Rigidbodyでの移動処理でキャラクターを移動する
        rigidbody.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    public void Move(Vector3 v, float moveSpeed) {
        // XXX : Ｙ軸を強制的に排除している
        velocity.x = v.x * moveSpeed;
        velocity.z = v.z * moveSpeed;
    }

    public void Jump(float power) {
        // 自身が持つ重力の反対方向に跳躍
        if (groundCollider)
        {
            velocity.y = downGravity ? power : -power;
        }
    }

    void OnCollisionEnter(Collision col) {
        // 重力方向にレイを飛ばして判定
        if (Physics.Linecast(transform.position, transform.position - gravity.normalized))
        {
            groundCollider = true;
        }
    }

    void OnCollisionExit() {
        groundCollider = false;
    }
}

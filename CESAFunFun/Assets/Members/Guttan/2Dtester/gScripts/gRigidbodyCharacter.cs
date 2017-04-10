using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gRigidbodyCharacter : MonoBehaviour
{

    //移動　ジャンプ　重力

    //移動速度
    public float _moveSpeed;
    //ジャンプ力
    public float _jumpPower;
    //足場判定
    public bool _isGrounded;
    //Rigidbody
    private Rigidbody2D rbody;

    private Vector2 velocity;

    void Start()
    {
        //Rigidbody取得
        rbody = GetComponent<Rigidbody2D>();
        // 移動量を初期化
        velocity = Vector2.zero;
        
    }
    void Update()
    {
        
    }
    public void Move(Vector2 pos, float speed)
    {
        //重要参考資料
        //http://qiita.com/adarapata/items/9218c15064b2f184182d

        pos = transform.position;
        pos.x += speed;
        transform.position = pos;

        // Y軸を移動を排除
        //velocity.x = pos.x * speed;

        //transform.LookAt2D(transform.position,new Vector2(velocity.x,0.0f));
        //transform.LookAt(transform.position + new Vector3(velocity.x, 0.0f,0.0f));
    }
    public void Jump(float power)
    {
        //地面に足がついていればジャンプ可能
        if (_isGrounded)
        {
            _isGrounded = false;
            rbody.AddForce(Vector2.up * power);
        }
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        //地面にFloorタグを設定する。
        //Floorに触れている間はジャンプ可能とする
        if(col.gameObject.tag=="Floor")
        {
            _isGrounded = true;
        }
    }
}

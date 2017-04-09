using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gRigidbodyCharacter : MonoBehaviour
{

    //移動　ジャンプ　重力

    //移動速度
    public float _moveSpeed = 1.0f;
    //ジャンプ力
    public float _jumpPower;
    //重力値 1通常 -1逆
    public int _gravityScore;

    private Vector2 velocity;

    void Start()
    {
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

    /*
public bool _downGravity = true;
public bool _isGrounded = false;
public bool _objected = false;

private Rigidbody2D rigidbody;
private Vector3 velocity;
private Vector3 gravity;

public float _moveSpeed = 1.0f;
public float _jumpPower = 1.0f;

//重力値 1通常 -1反対
public int _GravityScore;

public GameObject[] _children;

void Start()
{
    // アタッチされているRigidbodyを取得
    rigidbody = GetComponent<Rigidbody2D>();
    rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
    //useGravityがないので変更点
    //0が無重力 1が通常重力
    rigidbody.gravityScale = _GravityScore;
    //rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    //rigidbody.useGravity = false;
    // 移動量を初期化
    velocity = Vector3.zero;

    // タグ"Child"との衝突は無効化する
    IgnoreCharacter("Child", true);

    // 重力の方向の設定
    gravity = -Physics2D.gravity;
    if (_downGravity)
    {
        gravity *= -1F;
    }
}

void Update()
{
}

void FixedUpdate()
{
    // 自前で重力と接地の判定を計算
    if (_isGrounded)
    {
        velocity.y = 0F;
    }
    else
    {
        rigidbody.AddForce(gravity);
    }

    // Rigidbodyでの位置座標を更新
    rigidbody.MovePosition(transform.position + velocity * Time.deltaTime);
}

public void Move(Vector3 v, float speed)
{
    // XXX:Ｙ軸を意図的に排除している
    velocity.x = v.x * speed;
    velocity.z = v.z * speed;
    transform.LookAt(transform.position + new Vector3(velocity.x, 0F, velocity.z));
}

public void Jump(float power)
{
    // 接地しているときのみ跳躍
    if (_isGrounded)
    {
        _isGrounded = false;
        // 自身の上方向に跳躍
        Vector3 upVec = _downGravity ? Vector3.up : Vector3.down;
        rigidbody.AddForce(upVec * power * 100F);
    }
}

public void IgnoreCharacter(string tag, bool ignore)
{
    // 子要素との衝突判定は無視する
    _children = GameObject.FindGameObjectsWithTag(tag);
    for (int i = 0; i < _children.Length; i++)
    {
        Physics2D.IgnoreCollision(_children[i].GetComponent<Collider2D>(), GetComponent<Collider2D>(), ignore);
    }
}

void OnCollisionEnter(Collision other)
{
    //左右の壁のtagを　FloorからWallに変更
    //この場合のプログラムはFloorに接しているところが足場になるため
    //壁に引っ付いたら、その高さが足場になってしまう。
    if (other.gameObject.tag == "Floor")
    {
        // 接地判定のフラグを変更
        _isGrounded = true;
        if (_objected) rigidbody.isKinematic = true;
    }
}
*/
}

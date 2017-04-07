using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RigidbodyCharacter))]
public class Tracking : MonoBehaviour
{

    private RigidbodyCharacter character;

    public GameObject _target;

    private Transform target;

    [SerializeField]
    private float interval;
    

    // Use this for initialization
    void Start()
    {
        character = GetComponent<RigidbodyCharacter>();
        character._moveSpeed = _target.GetComponent<RigidbodyCharacter>()._moveSpeed;
        character._jumpPower = _target.GetComponent<RigidbodyCharacter>()._jumpPower;
    }

    // Update is called once per frame
    void Update()
    {
        if (!character._objected)
        {
            //ポジションの更新
            PosUpdate();
            //移動
            Move();

            //追従しているオブジェクトがジャンプしたら遅れてジャンプ
            if (!target.GetComponent<RigidbodyCharacter>()._isGrounded)
                Invoke("Jump", 0.2f);
        }
    }

    //ターゲットとのポジションを比較する
    bool Calcu(float target, float pos)
    {

        if (pos > target)
            return true;

        else
            return false;
    }

    //ポジションの更新
    void PosUpdate()
    {
        target = _target.transform;
    }
    //移動
    void Move()
    {
        float distance = target.transform.position.x - transform.position.x;

        //指定範囲内なら移動しない
        if (distance < interval && distance > -interval)
        {
            //キャラクターの移動
            character.Move(Vector3.zero, character._moveSpeed);
        }
        else
        {
            //ｘ座標を比較する
            if (Calcu(target.transform.position.x + interval, transform.position.x))
            {
                //キャラクターの移動
                character.Move(Vector3.left, character._moveSpeed);
            }
            else
            {
                //キャラクターの移動
                character.Move(Vector3.right, character._moveSpeed);
            }
        }
    }

    //ジャンプ
    void Jump()
    {
        //プレイヤーと同じだけ飛ぶ
        character.Jump(_target.GetComponent<RigidbodyCharacter>()._jumpPower);
    }
}

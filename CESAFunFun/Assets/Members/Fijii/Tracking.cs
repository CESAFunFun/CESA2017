using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{

    private RigidbodyCharacter character;

    [SerializeField]
    private GameObject _target;

    private Transform target;

    [SerializeField]
    private float interval;

    private float time;

    private bool jumpflag;

    // Use this for initialization
    void Start()
    {
        character = GetComponent<RigidbodyCharacter>();
        time = 0F;
    }

    // Update is called once per frame
    void Update()
    {

        PosUpdate();

        Move();

        jumpflag = _target.GetComponent<RigidbodyCharacter>()._isGrounded;
        if (!jumpflag)
        {
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
            Vector3 velocity = new Vector3(0, 0, 0);
            float speed = _target.GetComponent<RigidbodyCharacter>().moveSpeed;
            //キャラクターの移動
            character.Move(velocity, speed);
        }
        else
        {
            //ｘ座標を比較する
            if (Calcu(target.transform.position.x + interval, transform.position.x))
            {
                Vector3 velocity = new Vector3(-1, 0, 0);//_target.GetComponent<PlayerController>().velocity;
                float speed = _target.GetComponent<RigidbodyCharacter>().moveSpeed;
                //キャラクターの移動
                character.Move(velocity, speed);
            }
            else
            {
                Vector3 velocity = new Vector3(1, 0, 0);//_target.GetComponent<PlayerController>().velocity;
                float speed = _target.GetComponent<RigidbodyCharacter>().moveSpeed;
                //キャラクターの移動
                character.Move(velocity, speed);
            }
        }
    }

    //ジャンプ
    void Jump()
    {
        //プレイヤーと同じだけ飛ぶ
        character.Jump(_target.GetComponent<RigidbodyCharacter>().jumpPower);
    }
}

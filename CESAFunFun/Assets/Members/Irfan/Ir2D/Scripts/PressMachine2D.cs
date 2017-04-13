//-----------------------------------
//@! IRFAN FAHMI RAMADHAN
//
//@! PressMachine2D.cs
//-----------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressMachine2D : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;                //速度
    [SerializeField]
    private float backSpeed = 5;            //戻るための速度

    public bool _actived;                   //起動してるかどうか
    public bool _playerHit;                 //プレイヤーに当たるかどうか

    private Vector2 startPos;               //初期座標

    // Use this for initialization
    void Start()
    {
        //初期座標を初期化する
        startPos = new Vector2(transform.position.x, transform.position.y);
        //Triggerをつける
        GetComponent<BoxCollider>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        //起動したら挟む    
        if (_actived)
            transform.position = Vector2.MoveTowards(transform.position, transform.position - Vector3.up * speed, speed * Time.deltaTime);
        else
            //挟んだら元に戻る
            transform.position = Vector2.MoveTowards(transform.position, startPos, backSpeed * Time.deltaTime);
    }


    void OnTriggerEnter(Collider col)
    {
        //床に当たると元の所に戻す
        if (col.gameObject.tag == "Floor")
            _actived = false;

        //プレイヤーに当たる時
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
            col.gameObject.GetComponent<RigidbodyCharacter>()._isGrounded = false;
            _playerHit = true;

        }

        //子供に当たると消す
        if (_actived && col.gameObject.tag == "Child")
            Destroy(col.gameObject);
    }



}

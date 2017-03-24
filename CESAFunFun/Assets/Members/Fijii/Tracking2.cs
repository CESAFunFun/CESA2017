using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking2 : MonoBehaviour {

    public Transform _target;

    [SerializeField]
    private float interval;

    private Transform target;

    [SerializeField]
    private float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        PosUpdate();

        Move();

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
        target = _target;
    }
    //移動
    void Move()
    {

        float distance = target.transform.position.x - transform.position.x;

        //指定範囲内なら移動しない
        if (distance < interval && distance > -interval)
        {

        }
        else
        {
            //ｘ座標を比較する
            if (Calcu(target.transform.position.x + interval, transform.position.x))
                transform.Translate(-speed, 0, 0);
            else
                transform.Translate(speed, 0, 0);
        }
    }
}

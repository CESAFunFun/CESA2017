using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour {

    public Transform[] _target;

    [SerializeField]
    private float interval;

    private Transform target;

	// Use this for initialization
	void Start () {

        //InvokeRepeating("PosUpdate", 1, 0.1f);
    }
	
	// Update is called once per frame
	void Update () {

        PosUpdate();

        Move();

    }

    //ターゲットとのポジションを比較する
    bool Calcu(float target,float pos)
    {

        if (pos > target) 
            return true;

        else
            return false;
    }

    //ポジションの更新
    void PosUpdate()
    {
        float heuristic = 1000;
        target = _target[0];
        for (int i = 0; i < 5; i++) 
        {
            if(heuristic < target.position.x - _target[i].position.x)
            {
                heuristic = target.position.x - _target[i].position.x;
                target.position = _target[i].position;
            }
        }

    }
    //移動
    void Move()
    {

        float distance= target.transform.position.x - transform.position.x;

        //指定範囲内なら移動しない
        if (distance < interval && distance > -interval)
        {
            Debug.Log(distance);
        }
        else
        {
            //ｘ座標を比較する
            if (Calcu(target.transform.position.x + interval, transform.position.x))
                transform.Translate(-0.3f, 0, 0);
            else
                transform.Translate(0.3f, 0, 0);
        }

        distance = target.transform.position.y - transform.position.y;

        //指定範囲内なら移動しない
        if (distance < 0.1 && distance > -0.1)
        {
            Debug.Log(distance);
        }
        else
        {
            //y座標を比較する
            if (Calcu(target.transform.position.y, transform.position.y))
                transform.Translate(0, -1f, 0);
            else
                transform.Translate(0, 1f, 0);
        }
    }
}

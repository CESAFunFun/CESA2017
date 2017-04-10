//---------------------------------------
// IRFAN FAHMI RAMADHAN
//
// 2017/04/07
//
// DetectorScript.cs
//---------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorScript : MonoBehaviour {

    public bool _actived = false;                                   //床を動かすためのフラグ
    public bool _stopped = true;                                    //床が止まってるかどうかのフラグ

    [SerializeField]
    private float speed;                                            //動く速度
    [SerializeField]
    private Vector3 endPosition;                                    //止まる座標

    private List<GameObject> objs = new List<GameObject>();         //床に当たるオブジェクト
    private int objsNum = 0;                                        //床に当たるオブジェクトの数 
    private Transform floorParent;                                  //床自体
    

    private void Start()
    {
        //親から床を取得する
        floorParent = transform.parent;
    }

    private void Update()
    {
        objsNum = objs.Count;
        
        //if (objsNum == 0)
        //    objsNum = 1;
        //
        //endPosition = endPosition * objsNum;
        
        //Debug.Log(objsNum);
        
        if (_actived)
        {
            if (_stopped)
                floorParent.position = Vector3.MoveTowards(floorParent.position, endPosition, speed * Time.deltaTime);
            else
                floorParent.position = Vector3.MoveTowards(floorParent.position, Vector3.zero, speed * Time.deltaTime);
        }

        //もとのところに戻す
        if (floorParent.position == Vector3.zero)
        {
            _actived = false;
            _stopped = true;
        }

        Debug.Log("actived = " + _actived);
        Debug.Log("stopped = " + _stopped);

        //床にあたるオブジェクトのリストをクリアする
        objs.Clear();
    }



    void OnTriggerEnter(Collider col)
    {
        //プレイヤーが踏んだら動く
        if (col.gameObject.tag == "Player")
        {
            _actived = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //オブジェクトの数をリストに追加する
        if (other.gameObject.tag == "Player" && !objs.Contains(other.gameObject))
        {
            objs.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _stopped = false;
    }

    //オブジェクトの数を取得する
    public int getObjsNum()
    {
        return objsNum;
    }

}

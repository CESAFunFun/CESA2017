//---------------------------------------
// IRFAN FAHMI RAMADHAN
//
// FloorMovement.cs
//---------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour {
    [SerializeField]
    private float speed = 5;                    //床の速度

    private DetectorScript topDetector;         //上の判定
    private DetectorScript bottomDetector;      //下の判定
    private float totalNum;                     //計算用
    // Use this for initialization
	void Start ()
    {
        //判定を取得
        topDetector = transform.GetChild(0).GetComponent<DetectorScript>();
        bottomDetector = transform.GetChild(1).GetComponent<DetectorScript>();
    }
	
	// Update is called once per frame
	void Update () {
        
        //マイフレーム計算する
        totalNum = bottomDetector._objsNum + (topDetector._objsNum * (-1));

        //y座標がtotalNum分動く
        Vector3 endPosition = new Vector3(transform.position.x, totalNum, 0);

        //床を動かす
        transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);

    }
}

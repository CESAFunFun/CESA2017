using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gWallup : MonoBehaviour {

    [SerializeField]
    private gGoalScripts wallarea1;
    [SerializeField]
    private gGoalScripts wallarea2;
    [SerializeField]
    private GameObject walltop;
    [SerializeField]
    private GameObject wallbot;

    //移動時間フレーム
    private float timer;
    //Flag管理
    private bool _isGoalFlag;

	// Use this for initialization
	void Start ()
    {
        _isGoalFlag = false;
        timer = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //目的数達していたらゴールゲートを開ける
        if (wallarea1._isGoal && wallarea2._isGoal && !_isGoalFlag)
        {
            //walltop.transform.position += new Vector3(0.0f, 2f, 0f);
            //wallbot.transform.position -= new Vector3(0.0f, 2f, 0f);
            timer++;
            walltop.transform.position += new Vector3(0.0f, 0.1f, 0.0f);
            wallbot.transform.position -= new Vector3(0.0f, 0.1f, 0.0f);
            if (timer >= 20)
            {
                _isGoalFlag = true;
            }
        }
    }
}

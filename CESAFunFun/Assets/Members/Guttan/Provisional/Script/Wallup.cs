using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallup : MonoBehaviour {

    
    [SerializeField]
    private GoalScript wallarea1;
    [SerializeField]
    private GoalScript wallarea2;

    //GoalScriptsAndo wallarea;

    // bool flag;

    [SerializeField]
    private GameObject walltop;

    [SerializeField]
    private GameObject wallbot;

    //移動先ポジション設定
    public Transform _topTarget;
    public Transform _botTarget;
    //Flag管理
    private bool _isGoalFlag;
    //timeカウント
    private float timer;


	// Use this for initialization
	void Start ()
    {
        // wallarea = GameObject.Find("Goal/GoalMarker_Top").GetComponent<GoalScriptsAndo>();
        //Debug.Log(wallarea);
        timer = 0;
        _isGoalFlag = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
       //目的数達していたらゴールゲートを開ける
        if (wallarea1._isGoal&&wallarea2._isGoal&&!_isGoalFlag)
        {
            //walltop.transform.position += new Vector3(0.0f, 2f, 0f);
            //wallbot.transform.position -= new Vector3(0.0f, 2f, 0f);
            timer++;
            walltop.transform.position += new Vector3(0.0f, 0.1f, 0.0f);
            wallbot.transform.position -= new Vector3(0.0f, 0.1f, 0.0f);
            if (timer>=20)
            {
                _isGoalFlag = true;
            }
        }

    }
}

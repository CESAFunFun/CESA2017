using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallup : MonoBehaviour {

    
    [SerializeField]
    private GoalScriptsAndo wallarea1;
    [SerializeField]
    private GoalScriptsAndo wallarea2;

    [SerializeField]
    private GameObject walltop;

    [SerializeField]
    private GameObject wallbot;

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

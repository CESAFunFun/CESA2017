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

	// Use this for initialization
	void Start ()
    {
       // wallarea = GameObject.Find("Goal/GoalMarker_Top").GetComponent<GoalScriptsAndo>();
        //Debug.Log(wallarea);
    }
	
	// Update is called once per frame
	void Update ()
    {
       
        if (wallarea1._isGoal&&wallarea2._isGoal)
        {
            walltop.transform.position += new Vector3(0.0f, 2f, 0f);
            wallbot.transform.position -= new Vector3(0.0f, 2f, 0f);
        }
        

	}
}

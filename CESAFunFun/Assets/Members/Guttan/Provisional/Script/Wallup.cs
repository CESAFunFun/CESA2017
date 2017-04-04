using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallup : MonoBehaviour {

    private GoalScriptsAndo wallarea;
    private GameObject walltop;
    private GameObject wallbot;

	// Use this for initialization
	void Start ()
    {
        walltop = GameObject.Find("PressMachine/MachineTop");
        wallbot = GameObject.Find("PressMachine/MachineBottom");
    }
	
	// Update is called once per frame
	void Update () {
		
        if(wallarea._isGoal)
        {
            walltop.transform.position+= new Vector3(0.0f, 2f, 0f);
            wallbot.transform.position -= new Vector3(0.0f, 2f, 0f);
        }

	}

}

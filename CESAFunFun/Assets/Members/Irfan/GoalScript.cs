﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("GOAL");
        }
    }
    
}
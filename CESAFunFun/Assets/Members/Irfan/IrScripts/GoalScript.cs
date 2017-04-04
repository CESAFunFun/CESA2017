using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {
    public bool _isGoal = false;

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
            _isGoal = true;
    }

    void OnTriggerExit(Collider col)
    {
        //if (col.gameObject.tag == "Player")
            _isGoal = false;
    }
    
}

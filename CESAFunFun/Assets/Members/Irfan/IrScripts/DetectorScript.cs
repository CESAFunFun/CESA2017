using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorScript : MonoBehaviour {

    public bool _triggered;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            _triggered = true;
            Debug.Log("Triggered Entered");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controll : MonoBehaviour {
    
	// Use this for initialization
	void Start () {

        int layer = LayerMask.NameToLayer("Child");
        int layer2 = LayerMask.NameToLayer("Player");
        Physics.IgnoreLayerCollision(layer, layer2);
    }

    // Update is called once per frame
    void Update () {
    }
}

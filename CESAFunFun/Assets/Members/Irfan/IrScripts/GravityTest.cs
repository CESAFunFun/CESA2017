using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTest : MonoBehaviour {

    [SerializeField]
    private bool invertGravity = false;

    private Rigidbody rg;
	// Use this for initialization
	void Start () {
        rg = gameObject.GetComponent<Rigidbody>();
		
	}
    void Update()
    {
        if(invertGravity)
            rg.AddForce(-Physics.gravity, ForceMode.Acceleration);
        else
            rg.AddForce(Physics.gravity, ForceMode.Acceleration);

    }
}

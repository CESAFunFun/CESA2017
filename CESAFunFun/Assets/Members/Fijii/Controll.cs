using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controll : MonoBehaviour {

    private const float GRAVITY = -9.8f;
    private Vector3 vec;
    private CharacterController col;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        vec.y += GRAVITY * Time.deltaTime;
        col.Move(vec * Time.deltaTime);
	}
}

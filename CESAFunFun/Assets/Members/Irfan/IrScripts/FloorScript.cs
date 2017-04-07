using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    private DetectorScript detector;
    public Vector3 _stop = new Vector3(0,-1,0);
    public float _speed = 5;
	// Use this for initialization
	void Start ()
    {
        detector = GetComponentInChildren<DetectorScript>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(detector._actived)
        {
            Debug.Log("Turn down");
            //transform.Translate(Vector3.down * 5 * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, _stop, Time.deltaTime * _speed);
        }
		
	}
}

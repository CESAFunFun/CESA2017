using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressMachine : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float backSpeed = 5;

    private Vector3 startPos;
    private bool actived = false;

    private float time;



    //void OnCollisionEnter(Collision col)
    //{
    //    Debug.Log(col.gameObject.name);
    //    actived = false;
    //    if(col.gameObject.tag == "Player")
    //    col.gameObject.active = false;
    //}

    // Use this for initialization
    void Start ()
    {
        startPos = new Vector3(transform.position.x, transform.position.y);
        time = 0;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        time++;
        
        if (Input.GetKey(KeyCode.Z))
            actived = true;

        if (Input.GetKey(KeyCode.B))
            actived = false;

        //if (transform.position == Vector3.zero)
        //    actived = false;

        if(time >= 3 * 60)
            actived = false;
        

        MachineOn(actived);





    }

    public void MachineOn(bool on)
    {
        //if (on)
        //    transform.position = Vector3.Lerp(startPos, Vector3.zero, 25 * Time.deltaTime);
        //else
        //    transform.position = Vector3.MoveTowards(transform.position, startPos, backSpeed * Time.deltaTime);

        if (on)
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, startPos, backSpeed * Time.deltaTime);

    }



}

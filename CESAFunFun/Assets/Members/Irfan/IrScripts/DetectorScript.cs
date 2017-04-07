using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorScript : MonoBehaviour {

    public bool _actived;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Vector3 targetPos;
    private Transform floorParent;

    private Vector3 startPos = new Vector3(0,0,0);

    private void Start()
    {
        floorParent = transform.parent;
    }

    private void Update()
    {
        Debug.Log(floorParent.position);

        if (_actived)
            floorParent.position = Vector3.MoveTowards(floorParent.position, targetPos, speed * Time.deltaTime);
        else
            floorParent.position = Vector3.MoveTowards(floorParent.position, Vector3.zero, speed * Time.deltaTime);
    }

    void OnTriggerStay(Collider col)
    { 
        if (col.gameObject.tag == "Player")
        {

            _actived = true;
            //_triggered = true;
            Debug.Log("Triggered Stay");

            //floorParent.position = Vector3.MoveTowards(floorParent.position, targetPos, speed * Time.deltaTime);
        }
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        _actived = false;
        //floorParent.position = Vector3.MoveTowards(floorParent.position, Vector3.zero, speed * Time.deltaTime);
    }
}

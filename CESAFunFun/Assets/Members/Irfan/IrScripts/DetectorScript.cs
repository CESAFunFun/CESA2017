using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorScript : MonoBehaviour {

    public bool _actived = false;
    public bool _stopped = true;

    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 endPosition;

    //private Vector3 currentPosition;
    private Transform floorParent;

    private Vector3 startPos = new Vector3(0,0,0);

    private List<GameObject> objs = new List<GameObject>();

    private void Start()
    {
        floorParent = transform.parent;
        //currentPosition = floorParent.position;
    }

    private void Update()
    {
        if (_actived)
        {
            if (_stopped)
                floorParent.position = Vector3.MoveTowards(floorParent.position, endPosition, speed * Time.deltaTime);
            else
                floorParent.position = Vector3.MoveTowards(floorParent.position, Vector3.zero, speed * Time.deltaTime);   
        }

        if(floorParent.position == Vector3.zero)
        {
            _actived = false;
            _stopped = true;
        }

        Debug.Log(objs.Count);

        objs.Clear();
    }

    void OnTriggerEnter(Collider col)
    { 
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            _actived = true;
            //_stopped = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !objs.Contains(other.gameObject))
        {
            objs.Add(other.gameObject);
        }
    }
    //void OnTriggerExit(Collider other)
    //{
    //    //Debug.Log("Exit");
    //    //_actived = false;
    //    _stopped = false;
    //    //floorParent.position = Vector3.MoveTowards(floorParent.position, Vector3.zero, speed * Time.deltaTime);
    //}
}

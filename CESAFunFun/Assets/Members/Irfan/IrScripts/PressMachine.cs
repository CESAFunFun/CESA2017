using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressMachine : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float backSpeed = 5;

    public bool _actived;
    public bool _playerHit;

    private Vector3 startPos;

    // Use this for initialization
    void Start ()
    {
        startPos = new Vector3(transform.position.x, transform.position.y);
        GetComponent<BoxCollider>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {       
        if (_actived)
            transform.position = Vector3.MoveTowards(transform.position, transform.position - Vector3.up * 5, speed * Time.deltaTime); 
        else
            transform.position = Vector3.MoveTowards(transform.position, startPos, backSpeed * Time.deltaTime);

        Debug.Log("PM = " + _actived);

    }


    void OnTriggerEnter(Collider col)
    {

        if(col.gameObject.tag == "Floor")
            _actived = false;

        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.position = new Vector3(transform.position.x+2, transform.position.y*2, transform.position.z);
            col.gameObject.GetComponent<RigidbodyCharacter>()._isGrounded = false;
            _playerHit = true;

        }

        if (_actived && col.gameObject.tag == "Child")
            Destroy(col.gameObject);
    }



}

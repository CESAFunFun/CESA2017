﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressMachine : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float backSpeed = 5;

    public bool _actived = false;
    public bool _playerHit = false;

    private Vector3 startPos;
    private float time;
    
    
    // Use this for initialization
    void Start ()
    {
        startPos = new Vector3(transform.position.x, transform.position.y);
        GetComponent<BoxCollider>().isTrigger = true;
        time = 0;
    }

    // Update is called once per frame
    void Update ()
    {
        MachineOn(_actived);
    }

    public void MachineOn(bool on)
    {
        if (on)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            //time++;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, backSpeed * Time.deltaTime);
            //time = 0;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Floor")
            _actived = false;

        if(col.gameObject.tag == "Player")
            _playerHit = true;
        
    }



}

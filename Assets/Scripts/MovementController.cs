﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    private Vector3 forward, right, velocity, acceleration;
    private float accelspeed, frc;
    private bool ismoving;

    // Use this for initialization
    void Start () {
        print(transform.rotation);
        forward = Vector3.Normalize(Camera.main.transform.forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0))*forward;
        velocity = new Vector3(0, 0, 0);
        acceleration = new Vector3(0, 0, 0);
        accelspeed = .2f;
        ismoving = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey) // only execute if a key is being pressed
            Move();
        else
            ismoving = false;

            
    }
    void Move()
    {
        if (ismoving == false)
        {
            velocity = new Vector3(0, 0, 0);
            ismoving = true;
        }
           
        Vector3 rmove = right * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 vmove = forward * Time.deltaTime * Input.GetAxis("Vertical");

        acceleration = Vector3.Normalize(rmove + vmove);
        velocity += acceleration;

        transform.forward = Vector3.Normalize(rmove + vmove);
        transform.rotation *= Quaternion.Euler(new Vector3(0, 0, 90));

        transform.position += rmove * 8;
        transform.position += vmove * 8;
        

    }

}
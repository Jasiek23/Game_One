﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float range = 100.0f; // Range of bullet
    public float wait = 2f; // Time between shots
    public float shotCounter = 0f; //Counter of time between shots

    public GameObject bullet; // Object of bullet
    public float health; // 
    void Start()
    {
        
    }


    void Update()
    {
        if (shotCounter < wait) //Time between shots counter
        {
            shotCounter += Time.deltaTime;
        }

        if(Input.GetMouseButton(0) && shotCounter>= wait)
        {
            shotCounter = 0;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitInfo;

        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grassSwag : MonoBehaviour {

    Animator anim;
    float swagSpeed ;
    float swagTime = 60;

    // Use this for initialization
    void Start() { 
        
        anim = GetComponent<Animator>();
        anim.speed = Random.Range(0.5f, 2f);
       


    }
	
	// Update is called once per frame
	void Update () {

        if (swagTime >= 0)
        {
            swagTime -= 1;
        }
        else
        {
            anim.speed = Random.Range(0.5f, 2f);
            swagTime = Random.Range(60f, 180f);
        }


       


    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOSScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AIController controller;

    public bool makeAngry = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            controller.target = collider.gameObject;
            if(makeAngry){
                controller.makeAngry(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            controller.target = null;
            if(makeAngry){
                controller.makeAngry(false);
            }
        }
        
    }

    
}

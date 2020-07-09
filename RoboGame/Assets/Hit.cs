using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hit = false;
    void Start()
    {
        
    }

    void OnEnable(){

    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider){
        Debug.Log(collider.name);
        if(collider.gameObject.tag == "Player" && !hit && collider.isTrigger){
            hit = true;
            LifeManager.singleton.takeLife();
            
        }
    }
}

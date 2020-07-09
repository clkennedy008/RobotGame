using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPickup : MonoBehaviour
{
    // Start is called before the first frame update
    public bool pickedup = false;
    public int worth = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player" && !pickedup){
            for(int i = 0; i < worth; i ++){
                EnergyTracker.singleton.add();
            }
            GameObject.Destroy(this.gameObject);
            pickedup = true;
        }
        
    }
}

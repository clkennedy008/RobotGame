using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestorySelf : MonoBehaviour
{
    // Start is called before the first frame update
    public AIController controller;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameState.singleton.Victory && controller != null){
            controller.takeDamage(1000);
        }
    }

    public void destorySelf(){
        GameObject.Destroy(this.transform.parent.gameObject);
    }
}

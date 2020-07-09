using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            //WarpManager.singleton.canWarp = true;
            this.gameObject.GetComponent<Warp>().enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isShopWarp;

    public BoxCollider2D colTrig;
    void Start()
    {
        WarpManager.singleton.warps.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable(){
        if(WarpManager.singleton != null)
            WarpManager.singleton.canWarp = true;
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            if(isShopWarp){
                WarpManager.singleton.WarpBack(collider.gameObject);
            }else{
                WarpManager.singleton.LastWarpFrom = this.gameObject;
                WarpManager.singleton.WarpToShop(collider.gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            
        }
    }


}

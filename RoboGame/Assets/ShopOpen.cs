using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOpen : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool shopOpen = false;

    public static bool inBossRoom = false;

    public GameObject Shop;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player" && !inBossRoom){
            Shop.SetActive(true);
            if(ContollerCheck.singleton.controllerUsed){
                SelectionBox.singleton.Open();
            }
            shopOpen = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.tag == "Player" && !inBossRoom){
            Shop.SetActive(false);
            if(ContollerCheck.singleton.controllerUsed){
                SelectionBox.singleton.Close();
            }
            shopOpen = false;
        }
    }

    public static void Close(){
            if(ContollerCheck.singleton.controllerUsed){
                SelectionBox.singleton.Close();
            }
            shopOpen = false;
    }
}

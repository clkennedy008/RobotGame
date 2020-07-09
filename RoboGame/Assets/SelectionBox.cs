using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionBox : MonoBehaviour
{
    // Start is called before the first frame update
    public static SelectionBox singleton;
    public Button selected;

    public GameObject Shop;
    public int childSelected = 0;

    public bool pressed = false;
    void Start()
    {
        this.transform.position = Shop.transform.GetChild(childSelected).position;
        selected = Shop.transform.GetChild(childSelected).gameObject.GetComponentInChildren<Button>(true);
    }

    void Awake(){
        singleton = this;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!ShopOpen.shopOpen) return;
        if(pressed){
            if(Input.GetAxis("LeftShop") == 0 && Input.GetAxis("RightShop") == 0 && Input.GetAxis("CSubmit") == 0){
                pressed= false;
            }
        }
        if(Input.GetAxis("LeftShop") > 0 && !pressed){
            pressed = true;
            if(childSelected == 0){
                childSelected = Shop.transform.childCount - 1;
            }else{
                childSelected--;
            }
            this.transform.position = Shop.transform.GetChild(childSelected).position;
            selected = Shop.transform.GetChild(childSelected).gameObject.GetComponentInChildren<Button>(true);
        }
        if(Input.GetAxis("RightShop") > 0 && !pressed){
            pressed = true;
            if(childSelected == Shop.transform.childCount - 1){
                childSelected = 0;
            }else{
                childSelected ++;
            } 
            this.transform.position = Shop.transform.GetChild(childSelected).position;
            selected = Shop.transform.GetChild(childSelected).gameObject.GetComponentInChildren<Button>(true);
        }
        if(Input.GetAxis("CSubmit") > 0 && !pressed){
            pressed = true;
            if(selected != null){
                selected.onClick.Invoke();
            }
        }
    }

    public void Open(){
        this.gameObject.SetActive(true);
    }
    public void Close(){
        this.gameObject.SetActive(false);
    }
}

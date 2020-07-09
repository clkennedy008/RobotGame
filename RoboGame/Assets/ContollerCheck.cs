using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContollerCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public static ContollerCheck singleton;

    public float Angle;
    public bool controllerUsed = false;

    public GameObject Aimer;

    Vector2 OldMousePos;
    void Start()
    {
        OldMousePos = Input.mousePosition;
    }

    void Awake(){
        singleton = this;
    }
    // Update is called once per frame
    void Update()
    {   
        
        if(Input.GetAxisRaw("CHorz") != 0 || Input.GetAxisRaw("CVert") != 0 || Input.GetAxisRaw("Swing") > 0|| Input.GetAxisRaw("Lantern") > 0|| Input.GetAxisRaw("Warp") > 0
        || Input.GetAxisRaw("LeftShop") > 0|| Input.GetAxisRaw("RightShop") > 0|| Input.GetAxisRaw("CSubmit") > 0 ){
            //Debug.Log("CHorz | " + Input.GetAxisRaw("CHorz"));
            //Debug.Log("CVert | " + Input.GetAxisRaw("CVert"));
            //Debug.Log("Swing | " + Input.GetAxisRaw("Swing"));
            //Debug.Log("Lantern | " + Input.GetAxisRaw("Lantern"));
            //Debug.Log("Warp | " + Input.GetAxisRaw("Warp"));
            //Debug.Log("LeftShop | " + Input.GetAxisRaw("LeftShop"));
            //Debug.Log("RightShop | " + Input.GetAxisRaw("RightShop"));
            //Debug.Log("CSubmit | " + Input.GetAxisRaw("CSubmit"));
            //Debug.Log("FireGun | " + Input.GetAxisRaw("FireGun"));

            controllerUsed = true;
            Aimer.SetActive(true);
            Cursor.visible = false;
        }

        if((Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetKeyDown(KeyCode.F)|| Input.GetKeyDown(KeyCode.C)
                || Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.D) || !OldMousePos.Equals(Input.mousePosition)) 
                && !Application.isMobilePlatform){
            controllerUsed = false;
            Aimer.SetActive(false);
            Cursor.visible = true;
        }

        if(ContollerCheck.singleton.controllerUsed && ShopOpen.shopOpen){
            SelectionBox.singleton.Open();
        }else if(!ContollerCheck.singleton.controllerUsed && ShopOpen.shopOpen){
            SelectionBox.singleton.Close();
        }

        Angle = Mathf.Atan2(Input.GetAxis("CVert"), Input.GetAxis("CHorz")) * (180/Mathf.PI);

        OldMousePos = Input.mousePosition;
    }
}

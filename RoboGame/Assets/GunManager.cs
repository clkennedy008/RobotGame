using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunManager : MonoBehaviour
{
    public static GunManager singleton;
    // Start is called before the first frame update
    public GameObject LaserGunPrefab;

    public Gun Equipped;

    public Image buttonSprite;
    public GameObject fireButton;
    void Start()
    {
        singleton = this;

        Equipped = new Gun();

        fireButton.GetComponentInChildren<Button>(true).interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Equip(Gun.GunType type){
        
        switch(type){
            case Gun.GunType.LaserGun:
            GameObject o = GameObject.Instantiate(LaserGunPrefab);
            o.GetComponent<LaserGun>().setButtonSprite(buttonSprite);
            o.transform.SetParent(GunManager.singleton.transform);
            o.transform.localPosition = new Vector3(0,0,0);
            GunManager.singleton.Equipped = o.GetComponent<LaserGun>();
            break;
            default:
            GunManager.singleton.Equipped = null;
            break;
        }
        if(Application.isMobilePlatform && GunManager.singleton.Equipped != null){
            fireButton.GetComponentInChildren<Button>(true).interactable = true;
        }else if(Application.isMobilePlatform){
            fireButton.GetComponentInChildren<Button>(true).interactable = false;
        }
    }
}

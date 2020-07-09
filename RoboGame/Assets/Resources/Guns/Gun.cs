using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    public enum GunType{None, LaserGun}
    public GunType gunType = GunType.None;

    public GameObject Bullet;

    public bool canFire = true;

    public Image sprite;
    public Image buttonSprite;

    public virtual void Fire(Vector3 pos){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y - pos.y, mousePos.x - pos.x) * (180 / Mathf.PI);

        if(Application.isMobilePlatform){
            angle = JoyStickAngle.singleton.Angle;
        }
        if(ContollerCheck.singleton.controllerUsed){
            angle = ContollerCheck.singleton.Angle;
        }

        GameObject bul = GameObject.Instantiate(Bullet);
        bul.transform.position = pos;
        bul.transform.rotation = Quaternion.Euler(0,0,angle);
    }

    public virtual void Equip(){

    }

    public void setButtonSprite(Image bs){
        buttonSprite = bs;
    }
}

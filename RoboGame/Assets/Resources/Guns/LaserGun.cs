using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LaserGun : Gun
{   
    public Sprite phase1;
    public Sprite phase2;
    public Sprite phase3;
    public Sprite phase4;
    public Sprite recharged;

    public static int rechargelvl = 1;
    public static int rechargeMaxLvl = 5;

    public static int LaserSpeedlvl = 1;
    public static int LaserSpeedMaxlvl = 5;

    public float Recharge = 5f;
    public float RechargeTimer = 0f;
    public override void Equip(){
    }

    void Update(){
        if(!canFire){
            RechargeTimer += Time.deltaTime;
            float prec = RechargeTimer / (Recharge - (rechargelvl - 1));
            if(prec <= (1f/4f)){
                sprite.sprite = phase1;
                buttonSprite.sprite = phase1;
            }else if(prec <= (2f/4f)){
                sprite.sprite = phase2;
                buttonSprite.sprite = phase2;
            }else if(prec <= (3f/4f)){
                sprite.sprite = phase3;
                buttonSprite.sprite = phase3;
            }
            else if(prec < (3f/4f)){
                sprite.sprite = phase4;
                buttonSprite.sprite = phase4;
            }
            if(RechargeTimer > (Recharge - (rechargelvl - 1))){
                RechargeTimer = 0f;
                canFire = true;
                sprite.sprite = phase4;
                buttonSprite.sprite = phase4;
            }
        }else{
            if(sprite.sprite != recharged){
                sprite.sprite = phase4;
                buttonSprite.sprite = phase4;
            }
        }
    }

    public override void Fire(Vector3 pos){
        if(!canFire) return;
        sprite.sprite = recharged;
        buttonSprite.sprite = recharged;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y - pos.y, mousePos.x - pos.x) * (180 / Mathf.PI);

        if(Application.isMobilePlatform){
            angle = JoyStickAngle.singleton.Angle;
        }
        if(ContollerCheck.singleton.controllerUsed){
            angle = ContollerCheck.singleton.Angle;
        }

        GameObject bul = GameObject.Instantiate(Bullet);
        bul.GetComponentInChildren<Bullet>().speed += (LaserSpeedlvl - 1);
        bul.transform.position = pos;
        bul.transform.rotation = Quaternion.Euler(0,0,angle);

        canFire = false;
    }

    public static void increaseRechargeLevel(){
        if(rechargelvl == rechargeMaxLvl) return;
        rechargelvl ++;
    }

    public static void increaseSpeedLevel(){
        if(LaserSpeedlvl == LaserSpeedMaxlvl) return;
        LaserSpeedlvl ++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    // Start is called before the first frame update

    public int addHeartPrice = 5;

    public int addMaxHeartPrice = 20;
    public int addLanternPrice = 1;

    public int LanternRangePrice = 10;

    public int addWarpPrice = 10;

    public int increaseSwordDamagePrice = 10;
    public int LaserGunPrice = 25;
    public int LaserGunRechargePrice = 10;
    public int LaserGunSpeedPrice = 2;
    public int BossPrice = 100;

    public bool ownLaserGun = false;

    public TextMeshProUGUI addHeart;
    public TextMeshProUGUI addMaxHeart;
    public TextMeshProUGUI addLantern;
    public TextMeshProUGUI LanternRange;
    public TextMeshProUGUI LanternRangeLevel;

    public TextMeshProUGUI LaserGunBuyEquip;
    public TextMeshProUGUI LaserGunPriceText;

    public TextMeshProUGUI LaserGunRecPriceText;
    public TextMeshProUGUI LaserGunRecLvlText;
    public TextMeshProUGUI LaserGunSpeedPriceText;
    public TextMeshProUGUI LaserGunSpeedLvlText;

    public TextMeshProUGUI addWarp;

     public TextMeshProUGUI swordDamagePriceText;
     public TextMeshProUGUI swordDamageLvlText;

    public TextMeshProUGUI Boss;

    public GameObject theVoid;
    public GameObject BossRoom;

    public GameObject Loader;
    public GameObject unLoader;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            for(int i = 0; i < 100; i ++){
                EnergyTracker.singleton.add();
            }
        }
    }

    void OnEnable(){
        addHeart.text = addHeartPrice.ToString();
        addLantern.text = addLanternPrice.ToString();
        addMaxHeart.text = addMaxHeartPrice.ToString();

        addWarp.text = addWarpPrice.ToString();
        
        LanternRange.text = LanternRangePrice.ToString();
        LanternRangeLevel.text = "LVL " + Flicker.Level.ToString();

        swordDamagePriceText.text = increaseSwordDamagePrice.ToString();

        if(Sword.damageLevel == Sword.damageMaxLevel){
            swordDamagePriceText.transform.parent.GetComponent<Button>().interactable = false;
            swordDamageLvlText.text = "MAX";
        }else{
            swordDamagePriceText.transform.parent.GetComponent<Button>().interactable = true;
            swordDamageLvlText.text = "LVL " + Sword.damageLevel;
        }

        Boss.text = BossPrice.ToString();

        if(LifeManager.singleton.currentLife == LifeManager.singleton.maxLife){
            addHeart.transform.parent.GetComponent<Button>().interactable = false;
        }else{
            addHeart.transform.parent.GetComponent<Button>().interactable = true;
        }

        if(LanternManager.singleton.currentLantern == LanternManager.singleton.maxLantern){
            addLantern.transform.parent.GetComponent<Button>().interactable = false;
        }else{
            addLantern.transform.parent.GetComponent<Button>().interactable = true;
        }

        if(WarpManager.singleton.currentWarp == WarpManager.singleton.maxWarp){
            addWarp.transform.parent.GetComponent<Button>().interactable = false;
        }else{
            addWarp.transform.parent.GetComponent<Button>().interactable = true;
        }

        if(Flicker.Level == Flicker.maxLevel){
             LanternRange.transform.parent.GetComponent<Button>().interactable = false;
             LanternRangeLevel.text = "MAX";
        }else{
            LanternRange.transform.parent.GetComponent<Button>().interactable = true;
        }

        if(LaserGun.LaserSpeedlvl != LaserGun.LaserSpeedMaxlvl){
                LaserGunSpeedPriceText.transform.parent.GetComponent<Button>().interactable = true;
                LaserGunSpeedPriceText.text = LaserGunRechargePrice.ToString();
                LaserGunSpeedLvlText.text = "LVL " + LaserGun.LaserSpeedlvl.ToString();
        }else{
            LaserGunSpeedPriceText.transform.parent.GetComponent<Button>().interactable = false;
            LaserGunSpeedLvlText.text = "MAX";
        }

        if(LaserGun.rechargelvl != LaserGun.rechargeMaxLvl){
            LaserGunRecPriceText.transform.parent.GetComponent<Button>().interactable = true;
            LaserGunRecPriceText.text = LaserGunRechargePrice.ToString();
            LaserGunRecLvlText.text = "LVL " + LaserGun.rechargelvl.ToString();
        }else{
            LaserGunRecPriceText.transform.parent.GetComponent<Button>().interactable = false;
            LaserGunRecLvlText.text = "MAX";
        }

        if(!ownLaserGun){
            LaserGunPriceText.text = LaserGunPrice.ToString();
            LaserGunBuyEquip.text = "Buy";
            LaserGunSpeedPriceText.transform.parent.GetComponent<Button>().interactable = false;
            LaserGunRecPriceText.transform.parent.GetComponent<Button>().interactable = false;
        }else{
            LaserGunPriceText.text = "Owned";
            LaserGunBuyEquip.text = "Equip";
            
        }
    }

    public void BuyHeart(){
        if(EnergyTracker.singleton.Count >= addHeartPrice && LifeManager.singleton.currentLife < LifeManager.singleton.maxLife){
            EnergyTracker.singleton.spend(addHeartPrice);
            LifeManager.singleton.addLife();
        }
        if(LifeManager.singleton.currentLife == LifeManager.singleton.maxLife){
            addHeart.transform.parent.GetComponent<Button>().interactable = false;
        }
    }

    public void BuyMaxHeart(){
        if(EnergyTracker.singleton.Count >= addMaxHeartPrice){
            EnergyTracker.singleton.spend(addMaxHeartPrice);
            LifeManager.singleton.addMaxLife();
        }
        if(LifeManager.singleton.currentLife < LifeManager.singleton.maxLife){
            addHeart.transform.parent.GetComponent<Button>().interactable = true;
        }
    }

    public void BuyLantern(){
        if(EnergyTracker.singleton.Count >= addLanternPrice && LanternManager.singleton.currentLantern < LanternManager.singleton.maxLantern){
            EnergyTracker.singleton.spend(addLanternPrice);
            LanternManager.singleton.addLantern();
        }
        if(LanternManager.singleton.currentLantern == LanternManager.singleton.maxLantern){
            addLantern.transform.parent.GetComponent<Button>().interactable = false;
        }
    }

    public void BuySwordDamage(){
        if(EnergyTracker.singleton.Count >= increaseSwordDamagePrice && Sword.damageLevel < Sword.damageMaxLevel){
            EnergyTracker.singleton.spend(increaseSwordDamagePrice);
            Sword.increaseDamageLevel();
        }
        swordDamageLvlText.text = "LVL " + Sword.damageLevel;
        if(Sword.damageLevel == Sword.damageMaxLevel){
            swordDamagePriceText.transform.parent.GetComponent<Button>().interactable = false;
            swordDamageLvlText.text = "MAX";
        }
    }

    public void BuyWarp(){
        if(EnergyTracker.singleton.Count >= addWarpPrice && WarpManager.singleton.currentWarp < WarpManager.singleton.maxWarp){
            EnergyTracker.singleton.spend(addWarpPrice);
            WarpManager.singleton.addWarp();
        }
        if(WarpManager.singleton.currentWarp == WarpManager.singleton.maxWarp){
            addWarp.transform.parent.GetComponent<Button>().interactable = false;
        }
    }

    public void BuyLanternRange(){
        if(EnergyTracker.singleton.Count >= LanternRangePrice && Flicker.Level < Flicker.maxLevel){
            EnergyTracker.singleton.spend(LanternRangePrice);
            Flicker.increaseLevel();
        }
        LanternRangeLevel.text = "LVL " + Flicker.Level.ToString();
        if(Flicker.Level == Flicker.maxLevel){
             LanternRange.transform.parent.GetComponent<Button>().interactable = false;
             LanternRangeLevel.text = "MAX";
        }


    }

    public void BuyEquipLaserGun(){
        if(EnergyTracker.singleton.Count >= LaserGunPrice && !ownLaserGun){
            EnergyTracker.singleton.spend(LaserGunPrice);
            ownLaserGun = true;
            GunManager.singleton.Equip(Gun.GunType.LaserGun);
            LaserGunPriceText.text = "Owned";
            LaserGunBuyEquip.text = "Equip";
            LaserGunPriceText.transform.parent.GetComponent<Button>().interactable = false;

            if(LaserGun.LaserSpeedlvl != LaserGun.LaserSpeedMaxlvl){
                LaserGunSpeedPriceText.transform.parent.GetComponent<Button>().interactable = true;
                LaserGunSpeedPriceText.text = LaserGunRechargePrice.ToString();
                LaserGunSpeedLvlText.text = "LVL " + LaserGun.LaserSpeedlvl.ToString();
            }else{
                LaserGunSpeedPriceText.transform.parent.GetComponent<Button>().interactable = false;
                LaserGunSpeedLvlText.text = "MAX";
            }

            if(LaserGun.rechargelvl != LaserGun.rechargeMaxLvl){
                LaserGunRecPriceText.transform.parent.GetComponent<Button>().interactable = true;
                LaserGunRecPriceText.text = LaserGunRechargePrice.ToString();
                LaserGunRecLvlText.text = "LVL " + LaserGun.rechargelvl.ToString();
            }else{
                LaserGunRecPriceText.transform.parent.GetComponent<Button>().interactable = false;
                LaserGunRecLvlText.text = "MAX";
            }
        }else{

        }
    }

    public void BuyLaserRechargeLevel(){
        if(EnergyTracker.singleton.Count >= LaserGunRechargePrice && ownLaserGun && LaserGun.rechargelvl != LaserGun.rechargeMaxLvl){
            EnergyTracker.singleton.spend(LaserGunRechargePrice);
            LaserGun.increaseRechargeLevel();
            LaserGunRecLvlText.text = "LVL " + LaserGun.rechargelvl.ToString();
        }
        if(LaserGun.rechargelvl == LaserGun.rechargeMaxLvl){
             LaserGunRecPriceText.transform.parent.GetComponent<Button>().interactable = false;
             LaserGunRecLvlText.text = "MAX";
        }
    }

    public void BuyLaserSpeedLevel(){
        if(EnergyTracker.singleton.Count >= LaserGunSpeedPrice && ownLaserGun && LaserGun.LaserSpeedlvl != LaserGun.LaserSpeedMaxlvl){
            EnergyTracker.singleton.spend(LaserGunSpeedPrice);
            LaserGun.increaseSpeedLevel();
            LaserGunSpeedLvlText.text = "LVL " + LaserGun.LaserSpeedlvl.ToString();
        }
        if(LaserGun.LaserSpeedlvl == LaserGun.LaserSpeedMaxlvl){
             LaserGunSpeedPriceText.transform.parent.GetComponent<Button>().interactable = false;
             LaserGunSpeedLvlText.text = "MAX";
        }
    }

    public void enterBossRoom(){
        if(EnergyTracker.singleton.Count >= BossPrice){
            EnergyTracker.singleton.spend(BossPrice);
        }
        CameraShake.singleton.Shake();
        ShopOpen.inBossRoom = true;
        ShopOpen.shopOpen = false;
        Flicker.enterBossRoom();
        WarpManager.singleton.enterBossRoom();
        theVoid.SetActive(false);
        BossRoom.SetActive(true);
        Loader.SetActive(false);
        unLoader.SetActive(false);
        ShopOpen.Close();
        this.gameObject.SetActive(false);
    }


}

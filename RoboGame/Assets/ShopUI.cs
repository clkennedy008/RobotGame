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
    public int BossPrice = 100;

    public TextMeshProUGUI addHeart;
    public TextMeshProUGUI addMaxHeart;
    public TextMeshProUGUI addLantern;
    public TextMeshProUGUI LanternRange;
    public TextMeshProUGUI LanternRangeLevel;

    public TextMeshProUGUI Boss;
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
        
        LanternRange.text = LanternRangePrice.ToString();
        LanternRangeLevel.text = "LVL " + Flicker.Level.ToString();

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

        if(Flicker.Level == Flicker.maxLevel){
             LanternRange.transform.parent.GetComponent<Button>().interactable = false;
             LanternRangeLevel.text = "MAX";
        }else{
            LanternRange.transform.parent.GetComponent<Button>().interactable = true;
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
            LifeManager.singleton.maxLife += 1;
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
}

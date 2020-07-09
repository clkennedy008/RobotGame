using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanternManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static LanternManager singleton;
    public GameObject LanternPrefab;

    public GameObject LanternUIPrefab;
    public GameObject lanternPool;
    public GameObject Player;
    public float cooldown = 5f;
    public float coolDownTimer;

    public int maxLantern = 3;
    public int currentLantern = 3;
    public bool canPlace = true;

    public Slider cooldownSlider;
    void Start()
    {
        singleton = this;
        currentLantern = 1;
        singleton = this;
        for(int i = 0; i < currentLantern; i ++){
            GameObject heart = GameObject.Instantiate(LanternUIPrefab);
            heart.transform.SetParent(lanternPool.transform);
            heart.transform.localScale = new Vector3(1,1,1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!canPlace && currentLantern != 0){
            if(!cooldownSlider.gameObject.activeSelf){
                cooldownSlider.gameObject.SetActive(true);
            }
            coolDownTimer += Time.deltaTime;
            float perc = coolDownTimer / cooldown;
            cooldownSlider.value = perc;
            if(coolDownTimer > cooldown){
                coolDownTimer = 0f;
                canPlace = true;
                cooldownSlider.value = 1;
            }
        }

        if((Input.GetKey(KeyCode.F) || Input.GetAxis("Lantern") > 0) && canPlace && currentLantern != 0){
            GameObject o = GameObject.Instantiate(LanternPrefab);
            canPlace = false;
            o.transform.position = Player.transform.position;
            takeLantern();
            if(currentLantern == 0){
                cooldownSlider.gameObject.SetActive(false);
            }
        }
    }

    public void takeLantern(){
        currentLantern--;
        GameObject.Destroy(this.transform.GetChild(currentLantern).gameObject);
    }
    public void addLantern(){
        currentLantern++;
        GameObject heart = GameObject.Instantiate(LanternUIPrefab);
            heart.transform.SetParent(lanternPool.transform);
            heart.transform.localScale = new Vector3(1,1,1);
    }
    public void PlaceLantern(){
        if(canPlace && currentLantern != 0){
            GameObject o = GameObject.Instantiate(LanternPrefab);
            canPlace = false;
            o.transform.position = Player.transform.position;
            takeLantern();
            if(currentLantern == 0){
                cooldownSlider.gameObject.SetActive(false);
            }
        }
    }
}

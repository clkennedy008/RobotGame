using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    // Start is called before the first frame update
    public int Damage = 1;

    public bool Hit = false;

    public static int damageLevel = 1;
    public static int damageMaxLevel = 5;

    public GameObject baseSword;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable(){
        Hit = false;
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Spider" && !Hit){
            collider.gameObject.GetComponent<AIController>().takeDamage(Damage + (damageLevel - 1));
            Vector3 moveDir = this.transform.position -  collider.gameObject.transform.position;
            collider.gameObject.GetComponent<Rigidbody2D>().AddForce(moveDir.normalized * -7.5f, ForceMode2D.Impulse);
            Hit = true;
        }
        else if(collider.gameObject.tag == "Cannon" && !Hit){
            collider.gameObject.GetComponentInChildren<AIController>(true).takeDamage(Damage + (damageLevel - 1));
            Hit = true;
        }
        else if(collider.gameObject.tag == "Boss" && !Hit){
            Debug.Log(collider.name + " | " + collider.gameObject.name);
            collider.gameObject.GetComponentInChildren<BossEntrance>(true).takeDamage(Damage + (damageLevel - 1));
            Hit = true;
        }
    }

    public void Finish(){
        Hit = true;
    }

    public static void increaseDamageLevel(){
        if(damageLevel == damageMaxLevel) return;
        damageLevel ++;
    }
}

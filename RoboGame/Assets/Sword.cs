using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    // Start is called before the first frame update
    public int Damage = 1;

    public bool Hit = false;
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
            collider.gameObject.GetComponent<AIController>().takeDamage(Damage);
            Vector3 moveDir = this.transform.position -  collider.gameObject.transform.position;
            collider.gameObject.GetComponent<Rigidbody2D>().AddForce(moveDir.normalized * -7.5f, ForceMode2D.Impulse);
            Hit = true;
        }
    }
}

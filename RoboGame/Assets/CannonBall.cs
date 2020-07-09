using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed =5f;

    public float timeAlive = 10f;

    public float aliveTimer = 0f;

    public bool damageDone = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aliveTimer += Time.deltaTime;
        if(aliveTimer > timeAlive){
            GameObject.Destroy(this.gameObject);
        }
        
        this.transform.Translate(-Vector2.up * Time.deltaTime * speed);
        //this.transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, this.transform.localPosition + Vector3.right, Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player" && !damageDone){
            LifeManager.singleton.takeLife();
            GameObject.Destroy( this.gameObject);
            damageDone = true;
        }
    }
}

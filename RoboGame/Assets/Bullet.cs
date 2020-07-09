using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Hit = false;
    public int Damage = 1;
    public float timeAlive = 10f;

    public float aliveTimer = 0f;
    public float speed = 5f;
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
        
        this.transform.Translate(Vector2.right * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D collider){
        Debug.Log(collider.gameObject.name);
        if(collider.gameObject.tag != "Player" && !Hit && collider.gameObject.tag != "Untagged" && collider.gameObject.tag != "Boss")
        {   
            Hit = true;
            AIController ai = collider.gameObject.GetComponentInChildren<AIController>(true);
            if(ai != null){
                ai.takeDamage(Damage);
            }
            GameObject.Destroy(this.gameObject);
        }else if(collider.gameObject.tag != "Player" && !Hit && collider.gameObject.tag != "Untagged" && collider.gameObject.tag == "Boss"){
            Hit = true;
            BossEntrance ai = collider.gameObject.GetComponentInChildren<BossEntrance>(true);
            if(ai != null){
                ai.takeDamage(Damage);
            }
            GameObject.Destroy(this.gameObject);
        }
    }
}

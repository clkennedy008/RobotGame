using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D barrier;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Spider"){
            Transform en = collider.gameObject.transform;
            float angle = Mathf.Atan2(en.position.y - barrier.transform.position.y, en.position.x - barrier.transform.position.x) * (180 / Mathf.PI);
            Vector3 Ro = Quaternion.AngleAxis(angle, barrier.transform.forward) * Vector3.up; 

            en.position = Ro * ((CircleCollider2D)barrier).radius;
        }
    }

    void OnTriggerStay2D(Collider2D collider){
        if(collider.gameObject.tag == "Spider"){
            Transform en = collider.gameObject.transform;
            float angle = Mathf.Atan2(en.position.y - barrier.transform.position.y, en.position.x - barrier.transform.position.x) * (180 / Mathf.PI);
            Vector3 Ro = Quaternion.AngleAxis(angle, barrier.transform.forward) * Vector3.up; 

            en.position = Ro * ((CircleCollider2D)barrier).radius;
        }
    }
}

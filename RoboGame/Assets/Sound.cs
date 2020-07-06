using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource sound;

    public float chanceToSound = .2f;

    public float soundTime = 10f;
    public float soundTimer = 0f;

    public AIController controller;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.dead) return;

        soundTimer += Time.deltaTime;
        if(soundTimer > soundTime){
            soundTimer = 0f;
            if(Random.Range(0f,1f) < (float)(chanceToSound)){
                sound.PlayOneShot(sound.clip);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            if(Random.Range(0f,1f) < (float)(chanceToSound)){
                sound.PlayOneShot(sound.clip);
            }
            
        }
    }
}

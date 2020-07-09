using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    public static CameraShake singleton;
    public Animator shakeAnim;
    void Start()
    {
        singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shake(){
        shakeAnim.SetTrigger("Shake");
    }
}

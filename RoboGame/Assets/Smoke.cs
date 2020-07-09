using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem firePS;
    public ParticleSystem angryPS;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ThrowSmoke(){
        angryPS.Play();
    }

    public void Fire(){
        firePS.Play();
    }
}

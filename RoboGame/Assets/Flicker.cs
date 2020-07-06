using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class Flicker : MonoBehaviour
{
    // Start is called before the first frame update
    public static List<Flicker> lanterns = new List<Flicker>();
    public static int Level = 1;
    public static int maxLevel = 5;
    public Light2D light;
    public float minDist = 5;
    public float maxDist = 6;

    public float flickerTime = 2f;
    public float flickerTimer;

    void Start()
    {
        minDist += (Level - 1);
        maxDist += (Level - 1);
        lanterns.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        flickerTimer += Time.deltaTime;
        if(flickerTimer > flickerTime){
            float dist = Random.Range(minDist, maxDist);
            flickerTimer = 0f;
            light.pointLightOuterRadius = dist;
        }
    }

    public static void increaseLevel(){
        Level ++;
        foreach(Flicker f in lanterns){
            f.minDist += (1);
            f.maxDist += (1);
        }
    }
}

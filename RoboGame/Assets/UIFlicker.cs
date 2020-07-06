using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFlicker : MonoBehaviour
{
    // Start is called before the first frame update
    public float minDist = 1100;
    public float maxDist = 1200;

    public float flickerTime = .25f;
    public float flickerTimer;

    public RectTransform trans;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        flickerTimer += Time.deltaTime;
        if(flickerTimer > flickerTime){
            float dist = Random.Range(minDist, maxDist);
            flickerTimer = 0f;
            trans.sizeDelta =  new Vector2(dist, dist);
        }
    }
}

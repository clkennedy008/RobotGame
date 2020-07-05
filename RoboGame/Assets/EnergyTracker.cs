using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnergyTracker : MonoBehaviour
{
    public static EnergyTracker singleton;
    // Start is called before the first frame update
    public TextMeshProUGUI EnergyCountText;

    public GameObject EnergyPrefab;

    public int minEnergy = 1;
    public int maxEnergy = 5;

    public int distanceToNextIncrease = 3;

    public float spawnChance = 50f;

    public int Count;
    void Start()
    {
        singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void add(){
        Count ++;
        EnergyCountText.text = Count.ToString();
    }

    public void spawnEnergyOnChunk(GroundChunk gc){
        int toSpawn = (int)(Mathf.Sqrt((gc.pos.x * gc.pos.x) + (gc.pos.y * gc.pos.y)) / distanceToNextIncrease);

        if(toSpawn < minEnergy){
            toSpawn = minEnergy;
        }
        if(toSpawn > maxEnergy){
            toSpawn = maxEnergy;
        }

        for(int i = 0;i < toSpawn; i ++){
            if(Random.Range(0f, 1f) < (spawnChance / 100f)){
                Vector2 spawnPos = new Vector2(Random.Range((gc.size.x * gc.pos.x) - (gc.size.x /2), (gc.size.x * gc.pos.x) + (gc.size.x /2)),
                                                Random.Range((gc.size.y * gc.pos.y) - (gc.size.y /2), (gc.size.y * gc.pos.y) + (gc.size.y /2)));
                GameObject e =  GameObject.Instantiate(EnergyPrefab);
                e.transform.position = spawnPos;
                e.transform.SetParent(gc.transform);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public static CannonSpawner singleton;

    public GameObject CannonPrefab;

    public int minCannon = 0;
    public int maxCannon = 3;

    public int distanceToNextIncrease = 4;

    public float spawnChance = 50f;

    public int Count;
    void Start()
    {
        
    }
    void Awake(){
        singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnCannonOnChunk(GroundChunk gc){
        int toSpawn = (int)(Mathf.Sqrt((gc.pos.x * gc.pos.x) + (gc.pos.y * gc.pos.y)) / distanceToNextIncrease);

        if(toSpawn < minCannon){
            toSpawn = minCannon;
        }
        if(toSpawn > maxCannon){
            toSpawn = maxCannon;
        }

        for(int i = 0;i < toSpawn; i ++){
            if(Random.Range(0f, 1f) < (spawnChance / 100f)){
                Debug.Log((spawnChance / 100f));
                Vector2 spawnPos = new Vector2(Random.Range((gc.size.x * gc.pos.x) - (gc.size.x /2), (gc.size.x * gc.pos.x) + (gc.size.x /2)),
                                                Random.Range((gc.size.y * gc.pos.y) - (gc.size.y /2), (gc.size.y * gc.pos.y) + (gc.size.y /2)));
                GameObject e =  GameObject.Instantiate(CannonPrefab);
                e.transform.position = spawnPos;
                e.transform.SetParent(gc.transform);
                e.GetComponentInChildren<AIController>(true).groundChunk = gc;
            }
        }
    }
}

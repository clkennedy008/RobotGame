using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public static SpiderSpawner singleton;

    public GameObject SpiderPrefab;

    public int minSpider = 0;
    public int maxSpider = 3;

    public int distanceToNextIncrease = 4;

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

    public void spawnSpiderOnChunk(GroundChunk gc){
        int toSpawn = (int)(Mathf.Sqrt((gc.pos.x * gc.pos.x) + (gc.pos.y * gc.pos.y)) / distanceToNextIncrease);

        if(toSpawn < minSpider){
            toSpawn = minSpider;
        }
        if(toSpawn > maxSpider){
            toSpawn = maxSpider;
        }

        for(int i = 0;i < toSpawn; i ++){
            if(Random.Range(0f, 1f) < (spawnChance / 100f)){
                Debug.Log((spawnChance / 100f));
                Vector2 spawnPos = new Vector2(Random.Range((gc.size.x * gc.pos.x) - (gc.size.x /2), (gc.size.x * gc.pos.x) + (gc.size.x /2)),
                                                Random.Range((gc.size.y * gc.pos.y) - (gc.size.y /2), (gc.size.y * gc.pos.y) + (gc.size.y /2)));
                GameObject e =  GameObject.Instantiate(SpiderPrefab);
                e.transform.position = spawnPos;
                e.transform.SetParent(gc.transform);
                e.GetComponent<AIController>().groundChunk = gc;
            }
        }
    }
}

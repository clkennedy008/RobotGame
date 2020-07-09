using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GroundManager singleton;

    public GameObject GroundPrefab;
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

    public void makeChunk(Vector3 potentialPos){
        GameObject groundChunk = GameObject.Instantiate(GroundPrefab);
        GroundChunk gC = groundChunk.GetComponent<GroundChunk>();
        gC.pos = new Vector2(potentialPos.x, potentialPos.y);
        groundChunk.transform.SetParent(this.transform);
        groundChunk.transform.localPosition = gC.size * gC.pos;
        EnergyTracker.singleton.spawnEnergyOnChunk(gC);
        SpiderSpawner.singleton.spawnSpiderOnChunk(gC);
        CannonSpawner.singleton.spawnCannonOnChunk(gC);
        GroundChunk.Chuncks.Add(gC);
    }
}

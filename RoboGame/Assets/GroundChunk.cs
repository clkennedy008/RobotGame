using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChunk : MonoBehaviour
{
    // Start is called before the first frame update
    public static List<GroundChunk> Chuncks = new List<GroundChunk>();
    public Vector2 pos = new Vector2(0,0);

    public Vector2 size = new Vector2(20,20);
    void Start()
    {
        EnergyTracker.singleton.spawnEnergyOnChunk(pos, size);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            for(int x = -1; x <= 1; x ++){
                for(int y = -1; y <= 1; y ++){
                    if(y == 0 && x == 0){
                        continue;
                    }
                    Vector2 potentialPos = new Vector2(pos.x + x, pos.y + y);
                    bool alreadyExist = false;
                    foreach(GroundChunk g in Chuncks){
                        if(g.pos.Equals(potentialPos)){
                            alreadyExist = true;
                            break;
                        }
                    }

                    if(alreadyExist){
                        continue;
                    }else{
                        GameObject groundChunk = GameObject.Instantiate(this.gameObject);
                        GroundChunk gC = groundChunk.GetComponent<GroundChunk>();
                        gC.pos = new Vector2(potentialPos.x, potentialPos.y);
                        groundChunk.transform.SetParent(this.transform.parent);
                        groundChunk.transform.localPosition = gC.size * gC.pos;
                        Chuncks.Add(gC);
                    }
                }
            }
        }
    }
}

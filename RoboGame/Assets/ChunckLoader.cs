using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunckLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Loader = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.tag == "Ground" && !Loader){
            if(collider.gameObject.GetComponentInChildren<GroundChunk>(true).pos != new Vector2(0,0)){
                collider.gameObject.SetActive(false);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Ground" && Loader){
            Vector2 pos = collider.gameObject.GetComponentInChildren<GroundChunk>(true).pos;
            for(int x = -1; x <= 1; x ++){
                for(int y = -1; y <= 1; y ++){
                    if(y == 0 && x == 0){
                        continue;
                    }
                    Vector2 potentialPos = new Vector2(pos.x + x, pos.y + y);
                    foreach(GroundChunk g in GroundChunk.Chuncks){
                        if(g.pos.Equals(potentialPos)){
                            g.gameObject.SetActive(true);
                            break;
                        }
                    }
                }
            }
        }
    }
}

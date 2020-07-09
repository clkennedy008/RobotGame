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
    public GameObject EnergyHighValPrefab;

    public int minEnergy = 1;
    public int maxEnergy = 5;

    public int distanceToNextIncrease = 3;

    public float spawnChance = 50f;

    public float spawnChanceHighVal = 5f;

    public float slideSpeed = 1f;

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
                GameObject e =  null;
                if(Random.Range(0f, 1f) < (spawnChanceHighVal / 100f)){
                    e =  GameObject.Instantiate(EnergyHighValPrefab);
                }else{
                    e =  GameObject.Instantiate(EnergyPrefab);
                }
                
                e.transform.position = spawnPos;
                e.transform.SetParent(gc.transform);
            }
        }
    }

    public void spend(int amount){
        Count -= amount;
        EnergyCountText.text = Count.ToString();
    }

    public void spawnEnergy(int amount, Vector3 pos){
        for(int i = 0; i < amount; i ++){
            GameObject o = GameObject.Instantiate(EnergyPrefab);
            o.transform.position = pos;
            StartCoroutine(slide(o));
        }
    }

    IEnumerator slide(GameObject o){
        float angle = Random.Range(0f, 360f);
        //o.transform.rotation = Quaternion.Euler(0,0,angle);
        Vector3 Ro = Quaternion.AngleAxis(angle, o.transform.forward) * Vector3.up; 
        float temp = slideSpeed;
        do{
            //Debug.Log((Ro * slideSpeed));
            o.transform.position += (Ro * temp * Time.deltaTime) ;
            temp -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }while(temp > 0 && o != null);
        
        yield return new WaitForEndOfFrame();
    }
}

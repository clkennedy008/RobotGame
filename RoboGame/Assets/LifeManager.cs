using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static LifeManager singleton;
    // Start is called before the first frame update

    public int maxLife = 3;
    public int currentLife = 3;
    public bool isDead = false;
    public GameObject lifePool;
    public GameObject HeartPrefab;
    void Start()
    {
        currentLife = 3;
        singleton = this;
        for(int i = 0; i < currentLife; i ++){
            GameObject heart = GameObject.Instantiate(HeartPrefab);
            heart.transform.SetParent(lifePool.transform);
            heart.transform.localScale = new Vector3(1,1,1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L)){
            takeLife();
        }
        if(Input.GetKeyDown(KeyCode.K)){
            addLife();
        }
    }

    public void takeLife(){
        currentLife--;
        GameObject.Destroy(this.transform.GetChild(currentLife).gameObject);
        if(currentLife == 0){
            GameState.singleton.setGameOver();
        }
    }
    public void addLife(){
        currentLife++;
        GameObject heart = GameObject.Instantiate(HeartPrefab);
            heart.transform.SetParent(lifePool.transform);
            heart.transform.localScale = new Vector3(1,1,1);
    }
}

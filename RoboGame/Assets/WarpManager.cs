using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static WarpManager singleton;

    public GameObject WarpTo;

    public GameObject LastWarpFrom;

    public bool canWarp;

    public int maxWarp = 1;
    public int currentWarp = 0;
    public bool isDead = false;
    public GameObject WarpPool;
    public GameObject WarpUIPrefab;
    public GameObject WarpPrefab;

    public GameObject Player;

    public List<Warp> warps;
    void Start()
    {
        currentWarp = 1;
        singleton = this;
        warps = new List<Warp>();
        for(int i = 0; i < currentWarp; i ++){
            GameObject heart = GameObject.Instantiate(WarpUIPrefab);
            heart.transform.SetParent(WarpPool.transform);
            heart.transform.localScale = new Vector3(1,1,1);
        }
    }

    void Awake(){
        singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKey(KeyCode.C) || Input.GetAxis("Warp") > 0) && currentWarp != 0){
            GameObject o = GameObject.Instantiate(WarpPrefab);
            Vector2 dir = Player.GetComponentInChildren<CharacterController>(true).getDirection() *2;
            o.transform.position = Player.transform.position + new Vector3(dir.x, dir.y, 0) ;
            takeWarp();
        }
    }

    public void WarpToShop(GameObject player){
        if(!canWarp) return;
        WarpTo.GetComponent<Warp>().enabled = false;
        player.transform.position = WarpTo.transform.position;
        canWarp = false;
    }

    public void WarpBack(GameObject player){
        if(!canWarp || LastWarpFrom == null) return;
        LastWarpFrom.GetComponent<Warp>().enabled = false;
        player.transform.position = LastWarpFrom.transform.position;
        canWarp = false;
    }

    public void enterBossRoom(){
        for(int i = 0; i < warps.Count; i ++){
            GameObject.Destroy(warps[i].gameObject);
        }
        LastWarpFrom = null;
    }

    public void takeWarp(){
        currentWarp--;
        GameObject.Destroy(this.transform.GetChild(currentWarp).gameObject);
    }
    public void addWarp(){
        currentWarp++;
        GameObject heart = GameObject.Instantiate(WarpUIPrefab);
            heart.transform.SetParent(WarpPool.transform);
            heart.transform.localScale = new Vector3(1,1,1);
        
        //GameObject heart = GameObject.Instantiate(HeartPrefab);
            //heart.transform.SetParent(WarpPool.transform);
            //heart.transform.localScale = new Vector3(1,1,1);
    }

    public void PlaceWarp(){
        if(currentWarp != 0){
            GameObject o = GameObject.Instantiate(WarpPrefab);
            Vector2 dir = Player.GetComponentInChildren<CharacterController>(true).getDirection() *2;
            o.transform.position = Player.transform.position + new Vector3(dir.x, dir.y, 0) ;
            takeWarp();
        }
    }
}

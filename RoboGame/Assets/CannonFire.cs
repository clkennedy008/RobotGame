using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cannonPrefab;
    public Transform Cannon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fire(){
        GameObject o = GameObject.Instantiate(cannonPrefab);
        o.transform.position = Cannon.position;
        o.transform.rotation = Cannon.rotation;
    }
}

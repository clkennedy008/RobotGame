using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public float lerpSpeed = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Player.transform.position;
        Vector3 posCam = this.gameObject.transform.position;
        this.gameObject.transform.position = new Vector3(Mathf.Lerp(posCam.x, pos.x, Time.deltaTime * lerpSpeed), Mathf.Lerp(posCam.y, pos.y, Time.deltaTime * lerpSpeed), posCam.z);
    }
}

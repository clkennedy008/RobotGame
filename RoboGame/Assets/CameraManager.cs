using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    Camera MainCamera;
    public GameObject Player;
    public float lerpSpeed = 1f;

    Vector3 curPos;
    public float minSize = 3.5f;
    public float maxSize = 7f;
    public float defaultMaxSize = 7f;

    private float travelTime = 1f;
    private float travelTimeTimer = 0f;
    public static GameObject lookAt;

    public bool canZoom = true;
    public float ToOrthSize; 
    void Start()
    {
        MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        curPos = MainCamera.transform.position;
        ToOrthSize = MainCamera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Player.transform.position;
        Vector3 posCam = this.gameObject.transform.position;
        curPos = MainCamera.gameObject.transform.position;
        this.gameObject.transform.position = new Vector3(Mathf.Lerp(posCam.x, pos.x, Time.deltaTime * lerpSpeed), Mathf.Lerp(posCam.y, pos.y, Time.deltaTime * lerpSpeed), posCam.z);
        
        bindToWorld();
    
    }

    public void bindToWorld()
    {
        Vector3 rayPoimnt = MainCamera.ScreenToWorldPoint(new Vector3(MainCamera.pixelWidth / 2, 0,0));
        RaycastHit2D ray = Physics2D.Raycast(rayPoimnt, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Ground"));
        canZoom = true;
        if(ray.collider == null || ray.collider.gameObject.tag != "Ground")
        {
            MainCamera.gameObject.transform.position = new Vector3(MainCamera.gameObject.transform.position.x, curPos.y, curPos.z);
            maxSize = MainCamera.orthographicSize;
            canZoom = false;
        }
        Debug.DrawRay(rayPoimnt, Vector3.forward, Color.red, 5);

        rayPoimnt = MainCamera.ScreenToWorldPoint(new Vector3(MainCamera.pixelWidth / 2, MainCamera.pixelHeight, 0));
        ray = Physics2D.Raycast(rayPoimnt, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Ground"));
        if (ray.collider == null || ray.collider.gameObject.tag != "Ground")
        {
            MainCamera.gameObject.transform.position = new Vector3(MainCamera.gameObject.transform.position.x, curPos.y, curPos.z);
            maxSize = MainCamera.orthographicSize;
            canZoom = false;
        }
        Debug.DrawRay(rayPoimnt, Vector3.forward, Color.blue, 5);

        rayPoimnt = MainCamera.ScreenToWorldPoint(new Vector3(MainCamera.pixelWidth, MainCamera.pixelHeight / 2, 0));
        ray = Physics2D.Raycast(rayPoimnt, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Ground"));
        if (ray.collider == null || ray.collider.gameObject.tag != "Ground")
        {
            MainCamera.gameObject.transform.position = new Vector3(curPos.x, MainCamera.gameObject.transform.position.y, curPos.z);
            maxSize = MainCamera.orthographicSize;
            canZoom = false;
        }
        Debug.DrawRay(rayPoimnt, Vector3.forward, Color.green, 5);

        rayPoimnt = MainCamera.ScreenToWorldPoint(new Vector3(0, MainCamera.pixelHeight / 2, 0));
        //Debug.Log(rayPoimnt);
        ray = Physics2D.Raycast(rayPoimnt, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Ground"));
        if (ray.collider == null || ray.collider.gameObject.tag != "Ground")
        {
            MainCamera.gameObject.transform.position = new Vector3(curPos.x, MainCamera.gameObject.transform.position.y, curPos.z);
            maxSize = MainCamera.orthographicSize;
            canZoom = false;
        }
        Debug.DrawRay(rayPoimnt, Vector3.forward, Color.yellow, 5);
    }
}

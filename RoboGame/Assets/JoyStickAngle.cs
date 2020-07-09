using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickAngle : MonoBehaviour
{
    // Start is called before the first frame update
    public static JoyStickAngle singleton;
    public Transform Handle;

    public float Angle = 0;
    void Start()
    {
        
    }
    void Awake(){
        singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Handle.localPosition != new Vector3(0,0,Handle.localPosition.z)){
            Angle = Mathf.Atan2(Handle.localPosition.y, Handle.localPosition.x ) * (180/Mathf.PI);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


public class checkMobile : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern bool IsMobile();
    // Start is called before the first frame update
    void Start()
    {
        if(!Application.isMobilePlatform){
            this.gameObject.SetActive(false);
        }
    }

    public bool isMobile()
 {
     #if !UNITY_EDITOR && UNITY_WEBGL
         return IsMobile();
     #endif
     return false;
 }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateRotation : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.isMobilePlatform){
            this.transform.rotation = Quaternion.Euler(0,0, JoyStickAngle.singleton.Angle);
        }
        if(ContollerCheck.singleton.controllerUsed){
            this.transform.rotation = Quaternion.Euler(0,0, ContollerCheck.singleton.Angle);
        }
    }
}

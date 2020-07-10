using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpecialGift : MonoBehaviour
{
    // Start is called before the first frame update
    public bool pressedP;
    public bool pressedL;
    public bool pressedO;
    public bool pressedO2;

    public AnimatorOverrideController cont;
    public Animator animator;

    public bool inverted;

    public float keyPressTime = 1f;
    public float keyPressTimer = 0f;

    public float messageDisplayTime = 2f;
    public float messageDisplayTimer = 0f;
    public bool messageDisplayed= false;

    public TextMeshProUGUI display;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(messageDisplayed){
            messageDisplayTimer += Time.deltaTime;
            if(messageDisplayTimer > messageDisplayTime){
                messageDisplayTimer = 0f;
                messageDisplayed = false;
                display.gameObject.SetActive(false);
            }
        }
        
        if(inverted) return;
        if(Input.GetKeyDown(KeyCode.P)){
            pressedP = true;
            keyPressTimer=0f;

        }
        if(Input.GetKeyDown(KeyCode.L)){
            if(pressedP){
                pressedL = true;
                keyPressTimer=0f;
            }
            else{
                pressedL = false;
                pressedP = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.O) && pressedP){
            if(pressedL && pressedO){
                updateRobotModel();
                pressedL = false;
                pressedP = false;
                pressedO = false;
                pressedO2 = false;
            }else if(!pressedL){
                pressedL = false;
                pressedP = false;
                pressedO = false;
                pressedO2 = false;
            }
            if(pressedL && !pressedO2){
                pressedO = true;
                keyPressTimer=0f;
            }
            else{
                pressedL = false;
                pressedP = false;
                pressedO = false;
            }

            
        }
        if(pressedP || pressedL || pressedO){
            keyPressTimer += Time.deltaTime;
            if(keyPressTimer > keyPressTime){
                pressedL = false;
                pressedP = false;
                pressedO = false;
                pressedO2 = false;
            }
        }

    }

    public void updateRobotModel(){
        display.gameObject.SetActive(true);
        messageDisplayed = true;
        animator.runtimeAnimatorController = cont;
        inverted = true;
    }
}

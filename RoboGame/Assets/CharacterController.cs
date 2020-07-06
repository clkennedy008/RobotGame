﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public Animator BobAnimator;
    public Rigidbody2D RG;
    public SpriteRenderer spriteRenderer;

    public float moveSpeed = 1f;
    public bool moving = false;
    public bool movePressed = false;
    public Vector2 direction;
    public ParticleSystem particleSystem;

    public bool rooted = false;
    public float rootDuration = 1;
    public float rootTimer = 0f;
    public GameObject Sword;
    public Animator swordAnimator;

    public float attackCD = .25f;
    public float attackCDTimer = 0f;
    public bool canAttack = true;
    public bool attacked = false;
    void Start()
    {
        
    }

    // Update is called once per frame    void Update()
    void FixedUpdate(){

        Move();
        
    }

    public void Move()
    {
        if(GameState.singleton.GameOver || MainMenu.singleton.MainMenuOpen) return;

        movePressed = false;
        if(!rooted){
            if(Input.GetKey(KeyCode.W)){
                direction.y = 1;
                animator.SetFloat("Vert", direction.y);
                movePressed = true;
                if(!moving){
                    moving = true;
                    animator.SetBool("Moving", moving);
                    BobAnimator.SetBool("Moving", moving);
                    particleSystem.Play();
                }
            }else if(Input.GetKey(KeyCode.S)){
                direction.y = -1;
                animator.SetFloat("Vert", direction.y);
                movePressed = true;
                if(!moving){
                    moving = true;
                    animator.SetBool("Moving", moving);
                    BobAnimator.SetBool("Moving", moving);
                    particleSystem.Play();
                }
            }else{
                if(direction.x != 0){
                    direction.y = 0;
                    animator.SetFloat("Vert", direction.y);
                }
            }

            if(Input.GetKey(KeyCode.D)){
                direction.x = 1;
                animator.SetFloat("Horz", direction.x);
                movePressed = true;
                //spriteRenderer.flipX = false;
                if(!moving){
                    moving = true;
                    animator.SetBool("Moving", moving);
                    BobAnimator.SetBool("Moving", moving);
                    particleSystem.Play();
                }
            }else if(Input.GetKey(KeyCode.A)){
                direction.x = -1;
                animator.SetFloat("Horz", direction.x);
                movePressed = true;
                //spriteRenderer.flipX = true;
                if(!moving){
                    moving = true;
                    BobAnimator.SetBool("Moving", moving);
                    animator.SetBool("Moving", moving);
                    particleSystem.Play();
                }
            }else{
                if(direction.y != 0){
                    direction.x = 0;
                    animator.SetFloat("Horz", direction.x);
                }
            }
        }else{
            rootTimer += Time.deltaTime;
            if(rootTimer > rootDuration){
                rooted = false;
                rootTimer = 0f;
            }
        }
        

        if(!movePressed && moving){
            moving = false;
            animator.SetBool("Moving", moving);
            BobAnimator.SetBool("Moving", moving);
            particleSystem.Stop();
        }
        Vector2 vel = new Vector2(0,0);
        if(movePressed){
            vel = direction;
            if(vel.x != 0 && vel.y != 0){
                vel.x *= .75f;
                vel.y *= .75f;
            }
        }
        if(Sword.activeSelf && swordAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle")){
            Sword.SetActive(false);
            attacked = false;
        }

        if(!canAttack){
            attackCDTimer += Time.deltaTime;
            if(attackCDTimer > attackCD){
                canAttack = true;
                attackCDTimer = 0f;
            }  
        }

        if(Input.GetMouseButton(0) && !attacked && canAttack){
            attacked = true;

            canAttack = false;

            Vector2 mosPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float deltaX = mosPos.x - this.transform.position.x;
            float deltaY = mosPos.y - this.transform.position.y;
            //rooted = true;
            direction = new Vector2(0,0);
            Sword.SetActive(true);

            float angle = Mathf.Atan2((mosPos.y - this.transform.position.y) , (mosPos.x - this.transform.position.x) ) * (180/Mathf.PI);

            Sword.transform.rotation = Quaternion.Euler(0,0,angle);

            swordAnimator.SetTrigger("Swing");
           /* if(Mathf.Abs(deltaX) > Mathf.Abs(deltaY)){
                if(deltaX > 0){
                    swordAnimator.SetTrigger("Swing");
                    direction.x = 1;
                }else{
                    swordAnimator.SetTrigger("Swing");
                    direction.x = -1;
                }
            }else{
                if(deltaY <= 0){
                    swordAnimator.SetTrigger("Swing");
                    direction.y = -1;
                }else{
                    swordAnimator.SetTrigger("Swing");
                    direction.y = 1;
                }
            }*/
            animator.SetFloat("Horz", direction.x);
            animator.SetFloat("Vert", direction.y);
        }

        RG.MovePosition(new Vector2(this.transform.position.x, this.transform.position.y) + vel * moveSpeed * Time.deltaTime);
    }
}

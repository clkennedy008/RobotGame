using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public Rigidbody2D RG;
    public SpriteRenderer spriteRenderer;

    public float moveSpeed = 1f;
    public bool moving = false;
    public bool movePressed = false;
    public Vector2 direction;
    void Start()
    {
        
    }

    // Update is called once per frame    void Update()
    void FixedUpdate(){

        Move();
        
    }

    public void Move()
    {
        movePressed = false;
        
        if(Input.GetKey(KeyCode.W)){
            direction.y = 1;
            animator.SetFloat("Vert", direction.y);
            movePressed = true;
            if(!moving){
                moving = true;
                animator.SetBool("Moving", moving);
            }
        }else if(Input.GetKey(KeyCode.S)){
            direction.y = -1;
            animator.SetFloat("Vert", direction.y);
            movePressed = true;
            if(!moving){
                moving = true;
                animator.SetBool("Moving", moving);
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
            }
        }else if(Input.GetKey(KeyCode.A)){
            direction.x = -1;
            animator.SetFloat("Horz", direction.x);
            movePressed = true;
            //spriteRenderer.flipX = true;
            if(!moving){
                moving = true;
                animator.SetBool("Moving", moving);
            }
        }else{
            if(direction.y != 0){
                direction.x = 0;
                animator.SetFloat("Horz", direction.x);
            }
        }

        if(!movePressed && moving){
            moving = false;
            animator.SetBool("Moving", moving);
        }
        Vector2 vel = new Vector2(0,0);
        if(movePressed){
            vel = direction;
            if(vel.x != 0 && vel.y != 0){
                vel.x *= .75f;
                vel.y *= .75f;
            }
        }

        RG.MovePosition(new Vector2(this.transform.position.x, this.transform.position.y) + vel * moveSpeed * Time.deltaTime);
    }
}

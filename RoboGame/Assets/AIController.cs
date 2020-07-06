using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target = null;

    public Vector3 currentPos;
    public Vector3 oldPos;

    public float chaseSpeed =1f;

    public bool canMove = true;

    public bool attacked;

    public float attackCooldown = 3f;
    public float attackCDTimer = 0f;
    public float rootFromAttackTime = 1f;
    public float rootFromAttackTimer = 0f;

    public float angleAdjusment = 0f;
    public GroundChunk groundChunk;

    public Vector3 Moveto;

    public Animator animator;

    public bool canDamage = false;

    public bool reachedDestination = true;

    public float moveToDeadZone = .5f;

    public int health = 2;

    public Rigidbody2D rigidbody;

    public ParticleSystem deathParticles;

    public AudioSource dieSound;

    public bool dead;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameState.singleton.GameOver || ShopOpen.shopOpen || MainMenu.singleton.MainMenuOpen || dead) return;

        currentPos = this.transform.position;

        if(reachedDestination){
            Moveto = currentPos;
        }else{
            if(Mathf.Abs(currentPos.x - Moveto.x) < moveToDeadZone && Mathf.Abs(currentPos.y - Moveto.y) < moveToDeadZone){
                reachedDestination = true;
                oldPos = this.transform.position;
            }
        }
        

        if(attacked){
            attackCDTimer += Time.deltaTime;
            if(attackCDTimer > attackCooldown){
                attacked = false;
                attackCDTimer = 0f;   
            }
            if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Moving"))
            {   
                //canDamage = false;
            }
            if(!canMove){
                rootFromAttackTimer += Time.deltaTime;
                if(rootFromAttackTimer > rootFromAttackTime){
                    canMove = true;
                    rootFromAttackTimer = 0f;
                }
            }
        }

        if(target != null && canMove){
            Moveto = target.transform.position;
            reachedDestination = false;
        }else if(canMove && reachedDestination){
            if(groundChunk != null){
                Moveto = new Vector3(Random.Range((groundChunk.pos.x * groundChunk.size.x) - (groundChunk.size.x /2), (groundChunk.pos.x * groundChunk.size.x) + (groundChunk.size.x /2)),
                                    Random.Range((groundChunk.pos.y * groundChunk.size.y) - (groundChunk.size.y /2), (groundChunk.pos.y * groundChunk.size.y) + (groundChunk.size.y /2)), 0);
                reachedDestination = false;
            }
        }
        if(Moveto != currentPos){
            //this.transform.LookAt(Moveto, Vector3.up);
            float angle = Mathf.Atan2(Moveto.y - currentPos.y, Moveto.x - currentPos.x) * (180/Mathf.PI);
            angle -= angleAdjusment;
            this.transform.rotation = Quaternion.Euler(0,0,angle);
            //this.transform.position = new Vector3(Mathf.Lerp(currentPos.x, Moveto.x, Time.deltaTime * chaseSpeed), 
                   // Mathf.Lerp(currentPos.y, Moveto.y, Time.deltaTime * chaseSpeed), currentPos.z);
            this.transform.position=Vector3.MoveTowards(currentPos, Moveto, Time.deltaTime * chaseSpeed);
        }
        
    }

    public void Attack(){
        if(attacked){
            return;
        }
        //LifeManager.singleton.takeLife();
        canDamage = true;
        canMove = false;
        animator.SetTrigger("Attack");
        attacked = true;
    }

    public void takeDamage(int damage){
        health -= damage;
        animator.SetTrigger("Hit");
        
        if(health <= 0){
            animator.SetTrigger("Die");
            StartCoroutine(die());
            deathParticles.Play();
            dead = true;
            if(dieSound != null){
                dieSound.PlayOneShot(dieSound.clip);
            }
            
        }
    }

    IEnumerator die(){
        yield return new WaitForSeconds(10);
        GameObject.Destroy(this.gameObject);
    }
}

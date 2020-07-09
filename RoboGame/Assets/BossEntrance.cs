using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEntrance : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D Barrier;
    public CharacterController Player;

    public bool entrance = true;
    public GameObject spiderPrefab;

    public GameObject cannonPrefab;
    public int numberToSpawn = 3;

    public GameObject Ground;

    public GameObject target = null;

    public float angleAdjusment = 0f;

    public Vector3 currentPos;

    public bool dead;

    public int maxHealth = 20;
    public int health = 20;

    public bool rampaging = false;

    public float AttackTime = 5f;
    public float AttackTimer = 0f;

    public bool attacking;

    public Animator bossAnim;

    public Transform Boss;

    public bool setPosition = false;

    public ParticleSystem deathParticles;

    public AudioSource dieSound;

    public AudioSource moveSound;

    public AudioSource angrySound;

    public AudioSource crashSound;

    public int damageToRetreatDefault = 5;
    public int damageToRetreat = 5;

    public Transform RetreatPos;
    public Transform ReturnPos;
    public bool retreated = false;
    public bool returning = false;

    public float retreatTime = 7f;
    public float retreatTimer = 0f;

    public Collider2D hitBox;

    public bool canTakeDamage = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameState.singleton.GameOver || ShopOpen.shopOpen || MainMenu.singleton.MainMenuOpen || dead || entrance) return;

        currentPos = this.transform.position;

        if(target != null && !attacking){
            float angle = Mathf.Atan2(target.transform.position.y - currentPos.y, target.transform.position.x - currentPos.x) * (180/Mathf.PI);
            angle -= angleAdjusment;
            Boss.rotation = Quaternion.Euler(0,0,angle);
        }

        if(retreated && !returning){
            retreatTimer += Time.deltaTime;
            if(retreatTimer > retreatTime){
                retreatTimer = 0f;
                returning = true;
                Return();
            }
        }

        if(!attacking && !retreated){
            AttackTimer += Time.deltaTime;
            if(AttackTimer > AttackTime){
                AttackTimer = 0f;
                if(Random.Range(0f,1f) <= 1f)
                {
                    attacking = true;
                    chargeAttack();
                }  
            }
        }
    }

    void OnEnable(){
        health = maxHealth;
        Player.rootDuration = 10;
        Player.rooted = true;
        entrance = true;
        Barrier.enabled = false;
    }

    public void shake(){
        CameraShake.singleton.Shake();
    }

    public void endEntrance(){
        //this.transform.parent.position = this.transform.position;
        //this.transform.localPosition = new Vector3(0,0,0);
        setPosition = true;
        entrance = false;
        bossAnim.Play("Moving");
        if(rampaging){
            bossAnim.Play("Rampage");
        }
    }
    public void chargeAttack(){
        bossAnim.SetTrigger("Attack");
        //hitBox.enabled = false;
    }

    public void Return(){
        bossAnim.SetTrigger("Return");
    }
    public void ReturnMove(){
        this.transform.parent.transform.position = ReturnPos.position;
        retreated = false;
        returning = false;
        hitBox.enabled = true;
        
    }
    public void Retreat(){
        bossAnim.SetTrigger("Retreat");
        hitBox.enabled = false;
        canTakeDamage = false;
        retreated = true;
    }

    public void RetreatMove(){
        this.transform.parent.transform.position = RetreatPos.position;
        retreated = true;
        canTakeDamage = true;
    }

    public void spawnBabies(){
        int additional = 0;
        if(rampaging){
            additional = 2;
            GameObject cannon = GameObject.Instantiate(cannonPrefab);
            cannon.transform.SetParent(this.transform.parent.parent);
            cannon.transform.position = Boss.position;
        }
        for(int i = 0; i < numberToSpawn + additional; i ++){
            GameObject spider = GameObject.Instantiate(spiderPrefab);
            spider.transform.SetParent(this.transform.parent.parent);
            float angle = Random.Range(0f, 360f);
            Vector3 Ro = Quaternion.AngleAxis(angle, Boss.transform.forward) * Vector3.up;
            spider.transform.position = Boss.position + Ro * 2f;
            spider.GetComponentInChildren<AIController>(true).target = Player.gameObject;
        }
    }

    public void endAttack(){
        //this.transform.parent.position = this.transform.position;
        //this.transform.localPosition = new Vector3(0,0,0);
        
        bossAnim.Play("Moving");
        if(rampaging){
            bossAnim.Play("Rampage");
        }
        setPosition = true;
        attacking = false;
    }

    public void LateUpdate(){
        if(setPosition){
            setPosition = false;
            this.transform.parent.position = this.transform.position;
            this.transform.localPosition = new Vector3(0,0,0);
            //hitBox.enabled = true;
        }
    }

    public void takeDamage(int damage){
        if(dead || !canTakeDamage) return;
        health -= damage;
        damageToRetreat -= damage;
        if(!attacking){
            bossAnim.SetTrigger("Hit");
        }
        CameraShake.singleton.Shake();
        if(health <= 0){
            this.transform.parent.position = this.transform.position;
            this.transform.localPosition = new Vector3(0,0,0);
            damageToRetreat = damageToRetreatDefault;
            attacking = false;
            bossAnim.SetTrigger("Die");
            StartCoroutine(die());
            deathParticles.Play();
            dead = true;
            GameState.singleton.setVictory();
            if(dieSound != null){
                dieSound.PlayOneShot(dieSound.clip);
            }
            return;   
        }
        if(damageToRetreat <= 0){
            this.transform.parent.position = this.transform.position;
            this.transform.localPosition = new Vector3(0,0,0);
            damageToRetreat = damageToRetreatDefault;
            attacking = false;
            Retreat();
        }
        if(health < (maxHealth / 2) && !rampaging){
            AttackTime = AttackTime /2;
            rampaging = true;
        }
        
    }

    IEnumerator die(){
        yield return new WaitForSeconds(10);
        GameObject.Destroy(this.gameObject);
    }

    public void playMove(){
        moveSound.PlayOneShot(moveSound.clip);
    }

    public void playAngry(){
        angrySound.PlayOneShot(angrySound.clip);
    }

    public void crash(){
        crashSound.PlayOneShot(crashSound.clip);
    }
}

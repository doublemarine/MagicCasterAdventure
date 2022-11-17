using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed;
    public float     m_attenuation = 0.1f;
    public static Enemy instance;
    private Vector3 m_velocity;
private Animator anim = null;
private Transform target;
private bool skipMove = false;
public static int EnemyHp;
private CapsuleCollider2D capsule;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
           anim.SetBool("attack",true);
        }else if(other.gameObject.tag == "PlayerMagic"){
           anim.SetBool("hit",true);
           Invoke("Revive",1f);

            if(EnemyHp <= 0){
               anim.SetBool("die",true); 
               Invoke("DIE",0.5f);
               GManager.instance.enemies.Add(instance);
               capsule.enabled = false;
            } 
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
           anim.SetBool("attack",false);
        }else if(other.gameObject.tag == "PlayerMagic"){
            //anim.SetBool("hit",false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
         if(other.gameObject.tag == "Dark"){
            speed = speed / 2;
            Invoke("ResetSpeed",5f);
        }
    }

    public void ResetSpeed(){
        speed = speed * 2;
    }
    public void DIE(){
      // gameObject.SetActive(false);
      Destroy(gameObject);
    }
    public void Revive(){
        anim.SetBool("hit",false);
    }

    void Awake(){
         speed = 0.5f;
        EnemyHp = 10;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        capsule = GetComponent<CapsuleCollider2D>();
        speed = speed * GManager.instance.level;
        EnemyHp = EnemyHp * GManager.instance.level;
        Debug.Log(EnemyHp);
        
    }

    // Update is called once per frame
    void Update()
    {
        

       if(Vector2.Distance(transform.position,target.position) > 0f){
          transform.position = Vector2.MoveTowards(transform.position,target.position,speed*Time.deltaTime);
       }
        
    }
}

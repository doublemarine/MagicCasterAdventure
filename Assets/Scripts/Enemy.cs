using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed;
    public float     m_attenuation = 0.1f;

    private Vector3 m_velocity;
private Animator anim = null;
private Transform target;
private bool skipMove = false;
public static int EnemyHp;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
           anim.SetBool("attack",true);
        }else if(other.gameObject.tag == "PlayerMagic"){
           anim.SetBool("hit",true);

            if(EnemyHp <= 0){
               gameObject.SetActive(false);
              
            }
            
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
           anim.SetBool("attack",false);
        }else if(other.gameObject.tag == "PlayerMagic"){
            anim.SetBool("hit",false);
        }
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
       
        speed = speed * GManager.instance.level;
        EnemyHp = EnemyHp * GManager.instance.level;
        
    }

    // Update is called once per frame
    void Update()
    {
        

       if(Vector2.Distance(transform.position,target.position) > 0f){
          transform.position = Vector2.MoveTowards(transform.position,target.position,speed*Time.deltaTime);
       }
        
    }
}

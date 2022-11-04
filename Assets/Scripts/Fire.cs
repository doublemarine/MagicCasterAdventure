using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    private Transform m_target      = null;
    public float     m_speed       = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        m_target = GameObject.FindWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_target != null){
           if(Vector2.Distance(transform.position,m_target.position) > 0f){
          transform.position = Vector2.MoveTowards(transform.position,m_target.position,m_speed*Time.deltaTime);
          }
        }else if(m_target == null){
          Destroy(this.gameObject);
       }
        
       this.transform.LookAt(m_target.position);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Wall"){
            Destroy(gameObject);
        }else if(other.gameObject.tag == "Enemy"){
            Enemy.EnemyHp -= 30; 
            Destroy(gameObject);
        }
    }
}

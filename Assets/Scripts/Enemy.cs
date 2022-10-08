using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed = 1.0f;
    public float     m_attenuation = 0.5f;

    private Vector3 m_velocity;
private Animator anim = null;
private Transform target;
private bool skipMove = false;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
           anim.SetBool("attack",true);
        }else if(other.gameObject.tag == "PlayerMagic"){
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
           anim.SetBool("attack",false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        m_velocity += ( target.position - transform.position ) * speed;
        m_velocity *= m_attenuation;
        transform.position += m_velocity *= Time.deltaTime;
       
        
    }
}

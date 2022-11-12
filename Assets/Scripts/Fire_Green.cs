using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Green : MonoBehaviour
{
    private Transform m_target      = null;
    public float     m_speed       = 5;
    private SpriteRenderer renderer;
    
    // Start is called before the first frame update
    void Start()
    {
        m_target = GameObject.FindWithTag("Enemy").transform;
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = Color.green;
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
        
     
     LookAt2D(this.transform,m_target);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Wall"){
            Destroy(gameObject);
        }else if(other.gameObject.tag == "Enemy"){
            Enemy.EnemyHp -= 30; 
            Destroy(gameObject);
        }
    }

    public static void LookAt2D(Transform self, Transform _target)
	{
	    var current = self.position;
	    var direction = _target.position - current;
	    var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
	    self.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}

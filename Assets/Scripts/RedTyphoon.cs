using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTyphoon : MonoBehaviour
{

    private float speed;
    private Animator anim = null;
     private Rigidbody2D rb = null;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
         rb = GetComponent<Rigidbody2D>();
         speed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(speed,0,0);
    }

    private void OnEnable() {
        Invoke("Reset",7f);
    }

    public void Reset(){
        Destroy(gameObject);
    }
}

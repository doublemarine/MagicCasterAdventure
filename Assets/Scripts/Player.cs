using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject Camera;
    
    private GameObject fieldObject;
    private float speed;
    private Animator anim = null;
     private Rigidbody2D rb = null;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
         rb = GetComponent<Rigidbody2D>();
        fieldObject = GameObject.Find("Canvas");
        fieldObject.SetActive(false);
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
       Camera.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z - 10);

        if(Input.GetKey(KeyCode.Return)){
             fieldObject.SetActive(false);
             
        }
        else if(Input.GetKey(KeyCode.Slash)){
            fieldObject.SetActive(true);
        }
            
        Move();
    }

    public void Move(){
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 IdouHoukou = new Vector3(x, y, 0);

        //rbに力を加える
        //velocityは質量などの物理演算を無視するときに使う
        rb.velocity = IdouHoukou * speed;

         //rbの回転をさせない様にする
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}

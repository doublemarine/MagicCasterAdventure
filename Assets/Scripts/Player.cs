using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject Camera;
    public GameObject[] heartArray = new GameObject[5];
    public LayerMask blockingLayer;
    public static bool Isheal;
    private CapsuleCollider2D capsule;
    private int heartCount;
    
    private GameObject fieldObject;
    private float speed;
    private Animator anim = null;
     private Rigidbody2D rb = null;
    public AudioClip spell;
    AudioSource audioSource;
   

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            heartCount--;
            heartArray[heartCount].SetActive(false);
            anim.SetBool("hit",true);
            Invoke("Revive",0.2f);
            Debug.Log(heartCount);
        }
        if(heartArray[0].activeSelf == false){
            Loader.GameOverFlg = true;
            anim.SetBool("die",true);
            capsule.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Item"){
            Destroy(other.gameObject);
            GManager.instance.items.Add(Item.instance);
        }
        else if(other.gameObject.tag == "Exit"){
            Invoke("Restart",1f);
            //GManager.instance.ExitText.SetActive(false);
        }
    }

    public void Revive(){
        anim.SetBool("hit",false);
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capsule = GetComponent<CapsuleCollider2D>();
        fieldObject = GameObject.Find("Canvas");
        fieldObject.SetActive(false);
        Isheal = false;
        speed = 3f;
        heartCount = 5;
        Debug.Log(heartCount);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       Camera.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z - 5);

        if(Input.GetKey(KeyCode.Return)){
             fieldObject.SetActive(false);
             audioSource.PlayOneShot(spell);
        }
        else if(Input.GetKey(KeyCode.Space)){
            fieldObject.SetActive(true);
        }
        else if(Input.GetKey(KeyCode.Tab)){
            Application.Quit();
        }
            
        Move();
        HealIs();
    }

    public void HealIs(){
       if(Isheal == true){
        Isheal = false;
        heartArray[heartCount].SetActive(true);
        if(heartArray[4].activeSelf == true){
            return;
        }
       }
    }

    public void Move(){
        int x = (int)Input.GetAxisRaw("Horizontal");
        int y = (int)Input.GetAxisRaw("Vertical");
        
        if(x != 0){
            y = 0;
            if(x == 1){
                transform.localScale = new Vector3(1,1,1);
            }else
            {
                transform.localScale = new Vector3(-1,1,1);
            }
        }else if(y != 0){
            x = 0;
        }

        Vector3 IdouHoukou = new Vector3(x, y, 0);

        //rbに力を加える
        //velocityは質量などの物理演算を無視するときに使う
        rb.velocity = IdouHoukou * speed;

         //rbの回転をさせない様にする
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void Restart(){
        SceneManager.LoadScene(0);
    }
}

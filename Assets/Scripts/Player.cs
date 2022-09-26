using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    
    private GameObject fieldObject;

    // Start is called before the first frame update
    void Start()
    {
        
        fieldObject = GameObject.Find("Canvas");
        fieldObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKey(KeyCode.Return)){
             fieldObject.SetActive(false);
             
        }
        else if(Input.GetKey(KeyCode.Slash)){
            fieldObject.SetActive(true);
        }
            
        
    }
}

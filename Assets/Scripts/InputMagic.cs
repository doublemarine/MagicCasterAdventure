using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputMagic : MonoBehaviour
{

    public InputField inputField;
    public Text text;
    public GameObject fire;
    public GameObject dark;
    public GameObject redtyphoon;
    public GameObject Player;
    private Transform m_enemy = null;

    // Start is called before the first frame update
    void Start()
    {
        //Component��������悤�ɂ���
        inputField = inputField.GetComponent<InputField>();
        text = text.GetComponent<Text>();
        m_enemy = GameObject.FindWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputText()
    {
        //�e�L�X�g��inputField�̓��e�𔽉f
        text.text = inputField.text;
        if(text.text == "fire"){
            Fire();
            inputField.text = "";
        }
        else if(text.text == "dark"){
            Dark();
            inputField.text = "";
        }
        else if(text.text == "redtyphoon"){
            RedTyphoon();
            inputField.text = "";
        }
    }

    public void Fire()
    {
        Instantiate(fire, Player.transform.position, Quaternion.identity);
    }

    public void Dark(){
        Instantiate(dark, m_enemy.transform.position,Quaternion.identity);
    }

    public void RedTyphoon(){
        Instantiate(redtyphoon,new Vector3(Player.transform.position.x + 5,Player.transform.position.y,Player.transform.position.z), Quaternion.identity);
    }
}

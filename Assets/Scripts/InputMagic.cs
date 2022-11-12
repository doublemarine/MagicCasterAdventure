using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 

public class InputMagic : MonoBehaviour
{

    public InputField inputField;
    public Text text;
    public GameObject fire;
    public GameObject greenfire;
    public GameObject dark;
    public GameObject redtyphoon;
    public GameObject heal;
    public GameObject player;
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
        inputField.OnPointerClick(new PointerEventData(EventSystem.current));
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
            //Reset(redtyphoon);
        }
        else if(text.text == "heal"){
            Heal();
            inputField.text = "";
            ResetHeal(heal);
        }else if(text.text == "fire_bullet"){
            Fire_Bullet();
            inputField.text = "";
        }
    }

    public void ResetHeal(GameObject magic){
        magic = GameObject.FindWithTag("heal");
        Destroy(magic,1f);
    }
    public void Fire()
    {
        Instantiate(fire, player.transform.position, Quaternion.identity);
    }

    public void Dark(){
        Instantiate(dark, m_enemy.transform.position,Quaternion.identity);
    }

    public void RedTyphoon(){
        Instantiate(redtyphoon,new Vector3(player.transform.position.x + 5,player.transform.position.y,player.transform.position.z), Quaternion.identity);
    }

    public void Heal(){
        Instantiate(heal,player.transform.position,Quaternion.identity);
        Player.Isheal = true;

    }

    public void Fire_Bullet(){
        for(int i=0; i<3; i++){
            Instantiate(greenfire,player.transform.position,Quaternion.identity);
        }
    }

}

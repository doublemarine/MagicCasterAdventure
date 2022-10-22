using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public GameObject gameManager;
    public static bool GameOverFlg;
    public GameObject GameOverPanel;

    public void Awake() {
        if(GManager.instance == null){
            Instantiate(gameManager);
        }
    }

    void Start()
    {
        GameOverFlg = false;
        GameOverPanel.SetActive(false);
    }

    void Update()
    {
        if(GameOverFlg == true){
           GameOverPanel.SetActive(true);
           
        }
       
       
    }

    public void Continue(){
       SceneManager.LoadScene("SampleScene");
            Instantiate(gameManager);
    }

    public void Exit(){
        Application.Quit();
    }
}

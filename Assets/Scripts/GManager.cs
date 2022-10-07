using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance;
    BoardManager boardManager;


    private void Awake() {
        if(instance == null){
            instance = this;
        }else if(instance != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        boardManager = GetComponent<BoardManager>();
        InitGame();
    }

    public void InitGame(){
        boardManager.SetupScene();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

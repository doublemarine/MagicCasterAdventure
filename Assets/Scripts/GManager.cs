using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    public static GManager instance;
    BoardManager boardManager;
    private bool enemiesMoving = false;
    private bool playerturn = false;

    private List<Enemy> enemies;
    public int level = 1;
    private bool doingSetUp;
    

    private void Awake() {
        if(instance == null){
            instance = this;
        }else if(instance != this){
            Destroy(gameObject);
        }
        
        boardManager = GetComponent<BoardManager>();
        InitGame();

        //enemies = new List<Enemy>();
    }

    public void InitGame(){
        boardManager.SetupScene();
        //enemies.Clear();
    }

    public void AddEnemy(Enemy script){
        //enemies.Add(script);
    }

    public void DestroyEnemy(Enemy script){
       // enemies.Remove(script);
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

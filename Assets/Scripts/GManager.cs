using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    public static GManager instance;
    BoardManager boardManager;
    private bool enemiesMoving = false;
    private bool playerturn = false;

    public List<Enemy> enemies;
    public List<Item> items;
    public int level = 1;
    private bool doingSetUp;
    public Text levelText;
    public Text itemCount;
    public Text nowitemCount;
    public Text enemyCount;
    public Text nowenemyCount;
    public GameObject levelImage;
    public GameObject[] ItemCount,EnemyCount;
   

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

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static public void Call(){
       SceneManager.sceneLoaded += OnSceneLoaded;
    }

    static private void OnSceneLoaded(Scene next, LoadSceneMode a){
        instance.level++;
       instance.InitGame();
    }
    public void InitGame(){
        doingSetUp = true;

        levelImage = GameObject.Find("LevelImage");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        levelText.text = "Stage" + level;
        levelImage.SetActive(true);
        Invoke("HideLevelImage",2f);
        itemCount = GameObject.Find("ItemCount").GetComponent<Text>();
        enemyCount = GameObject.Find("EnemyCount").GetComponent<Text>();
        nowitemCount = GameObject.Find("NowItemCount").GetComponent<Text>();
        nowenemyCount = GameObject.Find("NowEnemyCount").GetComponent<Text>();
       

        boardManager.SetupScene();

        //enemies.Clear();
    }

    public void HideLevelImage(){
        levelImage.SetActive(false);
        doingSetUp = false;
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
        ItemCount = GameObject.FindGameObjectsWithTag("Item");
        EnemyCount = GameObject.FindGameObjectsWithTag("Enemy");
        itemCount.text = ItemCount.Length.ToString();
        enemyCount.text = EnemyCount.Length.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(doingSetUp){
            return;
        }
        nowitemCount.text = items.Count.ToString();
        nowenemyCount.text = enemies.Count.ToString();
    }
}

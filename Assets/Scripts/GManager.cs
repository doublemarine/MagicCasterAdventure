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

    private List<Enemy> enemies;
    public int level = 1;
    private bool doingSetUp;
    public Text levelText;
    public GameObject levelImage;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(doingSetUp){
            return;
        }
       
    }
}

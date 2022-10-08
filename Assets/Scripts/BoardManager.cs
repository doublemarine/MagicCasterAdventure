using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public int colums = 8, rows = 8;
    private List<Vector3> gridPositions = new List<Vector3>();
    public GameObject[] floorTiles;
    public GameObject[] wallTiles;
    public GameObject[] outwallTiles;
    public GameObject[] enemyTiles;

    public int wallMinimum = 5, wallMaximum = 9;
    public int enemyMinimum = 1, enemyMaximum = 9;

    
    void InitialiseList(){
        gridPositions.Clear();

        for(int x=1; x<colums-1; x++){
            for(int y=1; y<rows-1; y++){
                gridPositions.Add(new Vector3(x,y,0));
        }
        }
    }

    void BoardSetUp(){
        for(int x=-1; x<colums+1; x++){
            for(int y=-1; y<rows+1; y++){
                GameObject toInstantiate;

                if(x == -1 || x == colums || y == -1 || y == rows){
                    toInstantiate = outwallTiles[Random.Range(0,outwallTiles.Length)];
                }
                else{
                    toInstantiate = floorTiles[Random.Range(0,floorTiles.Length)];
                }
                Instantiate(toInstantiate,new Vector3(x,y,0),Quaternion.identity);
        }
        }
    }

    Vector3 RandomPosition(){
        int randomIndex = Random.Range(0,gridPositions.Count);

        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);

        return randomPosition;
    }

    void LayoutObjectatRandom(GameObject[] tileArray, int min, int max){
        int objectCount  = Random.Range(min, max+1);

        for(int i=0; i<objectCount; i++){
            Vector3 randomPosition = RandomPosition();

            GameObject tileChoice = tileArray[Random.Range(0,tileArray.Length)];

            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    public void SetupScene(){
        BoardSetUp();
        InitialiseList();
        LayoutObjectatRandom(wallTiles, wallMinimum, wallMaximum);
       // int enemyCount = (int)Mathf.Log(level,2f);
        LayoutObjectatRandom(enemyTiles, enemyMinimum, enemyMaximum);
    }
        
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnerScript : MonoBehaviour
{
    public GameObject monsterPrefab;

    public float[,] monsterLocations = new float[2,2]{
        {1.0f,1.0f},
        {-2.0f,-6.0f}
        // {2.0f,6.0f},
        // {-1.0f,-1.0f},
        // {3.0f,4.0f},
        // {12.0f,8.0f},
        // {11.0f,-4.0f},
        // {4.0f,8.0f},
        // {13.0f,11.0f},
        // {-12.0f, -9.0f}
    };



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(monsterLocations.Length);
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn(){
        for(int i = 0; i < monsterLocations.GetLength(0); i++){
        GameObject monster = Instantiate(monsterPrefab) as GameObject;
        monster.transform.position = new Vector2(monsterLocations[i,0],monsterLocations[i,1]);
        
        }
    }
}

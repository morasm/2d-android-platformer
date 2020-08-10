using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnerScript : MonoBehaviour
{
    public GameObject monsterPrefab;
    public GameObject crabPrefab;

    public float[,] monsterLocations = new float[10,2]{
        {-10.0f,14.0f},
        {-18.0f,7.0f},
        {-6.0f,2.0f},
        {-22.0f,-4.0f},
        {57.0f,-4.0f},
        {80.0f,9.0f},
        {76.0f,-16.0f},
        {62.0f,-28.0f},
        {5.0f,-28.5f},
        {1.0f, -16.0f}
    };

    public float[,] crabLocations = new float[8,2]{
        {6.6f, 18.50f},
        {18.6f, 11.6f},
        {10.6f, -12.2f},
        {31.6f, -30.3f},
        {48.6f, -12.6f},
        {-20.4f, -36.4f},
        {35.0f,-36.3f},
        {90.0f, -24.2f}
    };

    void Start()
    {
        Spawn();
    }

    private void Spawn(){
        for(int i = 0; i < monsterLocations.GetLength(0); i++){
        GameObject monster = Instantiate(monsterPrefab) as GameObject;
        monster.transform.position = new Vector2(monsterLocations[i,0],monsterLocations[i,1]);
        }

        for(int i = 0; i < crabLocations.GetLength(0); i++){
        GameObject crab = Instantiate(crabPrefab) as GameObject;
        crab.transform.position = new Vector2(crabLocations[i,0],crabLocations[i,1]);
        }
    }
}

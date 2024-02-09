using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    private GameManager man;
    public GridLayout grid;
    public GameObject[] enemies = new GameObject[5];
    int enemySize;
    bool spawning = true;
    // Start is called before the first frame update
    void Start()
    {
        man = GameManager.Instance;
        if (man.loudness <= 0.5) enemySize = 3;
        else enemySize = 5;
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    IEnumerator SpawnEnemy()
    {
        while(spawning) //Coroutines needed to be in a loop
        {
            float x = UnityEngine.Random.Range(-11, 10);
            float y = UnityEngine.Random.Range(-5, 4);
            Vector3 spawnPos = new Vector3(x, y, 0);
            Collider[] intersection = Physics.OverlapSphere(new Vector2(x, y), 0.5f);
            if(intersection.Length == 0) 
            {
                int enemy = (int)UnityEngine.Random.Range(0, enemySize);
                if (enemy == enemySize) enemy = enemySize - 1;
                Instantiate(enemies[enemy], spawnPos, Quaternion.identity);
                yield return new WaitForSeconds(man.time_signature);
            }
            else
            {
                yield return new WaitForSeconds(man.time_signature);
            }
        }
    }
}

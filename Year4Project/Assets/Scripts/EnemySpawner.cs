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
    public LayerMask layers;
    public float spawnRadius;
    public static int enemiesSpawned;
    // Start is called before the first frame update
    void Start()
    {
        man = GameManager.Instance;
        if (man.loudness <= 0.5) enemySize = 3;
        else enemySize = 5;
        enemiesSpawned = 0;
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    private void Update()
    {
        //if (enemiesSpawned < 5) StartCoroutine("SpawnEnemy");
        //else if (enemiesSpawned >= 5) StopCoroutine("SpawnEnemy");
    }
    IEnumerator SpawnEnemy()
    {
        while(spawning) //Coroutines needed to be in a loop
        {
            float x = UnityEngine.Random.Range(-10, 9);
            float y = UnityEngine.Random.Range(-4, 3);
            Vector3 spawnPos = new Vector3(x, y, 0);
            Collider2D[] intersection = Physics2D.OverlapCircleAll(new Vector2(x, y), spawnRadius, layers);
            if(intersection.Length == 0) 
            {
                int enemy = (int)UnityEngine.Random.Range(0, enemySize);
                if (enemy == enemySize) enemy = enemySize - 1;
                Instantiate(enemies[enemy], spawnPos, Quaternion.identity);
                enemiesSpawned++;
                yield return new WaitForSeconds(man.time_signature);
            }
            else
            {
                yield return new WaitForSeconds(0);
            }
        }
    }
}

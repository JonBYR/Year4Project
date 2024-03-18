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
    public LayerMask layers;
    public float spawnRadius;
    public static int enemiesSpawned;
    // Start is called before the first frame update
    void Start()
    {
        man = GameManager.Instance;
        if (man.loudness >= -7.5) enemySize = 3; //loudness is measured in the API as being between -60 and 0 with -60 being the lowest
        else enemySize = 5;
        enemiesSpawned = 0;
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(enemiesSpawned);
    }
    IEnumerator SpawnEnemy()
    {
        while(enemiesSpawned <= 10000) //Coroutines needed to be in a loop
        {
            if(enemiesSpawned >= 5)
            {
                yield return new WaitUntil(() => enemiesSpawned < 5); //creates a delegate that waits until number of enemies spawned goes down before spawning a new enemy
            }
            float x = UnityEngine.Random.Range(-7, 7);
            float y = UnityEngine.Random.Range(-3, 3);
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

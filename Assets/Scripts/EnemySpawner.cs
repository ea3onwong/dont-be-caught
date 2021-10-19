using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   

    public GameObject[] enemies;
    public Transform[] spawnPoints;

    private GameObject spawnedEnemy;
    private float spawnRate;
    private float nextSpawn; 
    private int enemyIndex, spawnPointIndex;

    private void Start() {
        nextSpawn = 0.0f;
    }

    private void Update() {
        SpawnEnmey();
    }

    private void SpawnEnmey() {
        spawnRate = Random.Range(0.35f, 2.5f);
        
        if (Time.time > nextSpawn) {
            nextSpawn = Time.time + spawnRate;

            enemyIndex = Random.Range(0, enemies.Length);
            spawnPointIndex = Random.Range(0, spawnPoints.Length);

            spawnedEnemy = Instantiate(enemies[enemyIndex], spawnPoints[spawnPointIndex].position, Quaternion.identity);

            if (spawnPointIndex == 0) {
                MoveToRight();
            } else if (spawnPointIndex == 1) {
                MoveToLeft();
            } else {
                RandomMove();
            }  
        }
    }

    private void MoveToRight() {
        spawnedEnemy.GetComponent<Enemy>().speed = Random.Range(1f, 3.5f);
        if (Random.Range(0, 3) == 1) {
            spawnedEnemy.GetComponent<Enemy>().doJumping = true;
        }
    }

    private void MoveToLeft() {
        spawnedEnemy.GetComponent<Enemy>().speed = -Random.Range(1f, 3.5f);  
        spawnedEnemy.transform.localScale = new Vector3(-1f, 1f, 1f);
        if (Random.Range(0, 3) == 1) {
            spawnedEnemy.GetComponent<Enemy>().doJumping = true;
        }
    }

    private void RandomMove() {
        if (Random.Range(0, 5) % 2 == 0) {
            MoveToRight();
        } else {
            MoveToLeft();
        }
    }
}






















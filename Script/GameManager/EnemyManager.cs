using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject ExpDropPrefab;
    [SerializeField] private GameObject HealthDropPrefab;
    [SerializeField] private float HealthDropChance;
    [SerializeField] private float dropForce;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval;
    [SerializeField] private float enemySpeed;
    [SerializeField] private Transform player;
    private float nextSpawnTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextSpawnTime){
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy(){
        int randomIndex = Random.Range(0, spawnPoints.Length);
        GameObject enemy = Instantiate(enemyPrefab, spawnPoints[randomIndex].position, spawnPoints[randomIndex].rotation);
        
        EnemyControl enemyControl = enemy.GetComponent<EnemyControl>();
        enemyControl.player = player;
        enemyControl.speed = enemySpeed;

        EnemyDropControl enemyDropControl = enemy.GetComponent<EnemyDropControl>();
        enemyDropControl.setExpDrop(ExpDropPrefab);
        enemyDropControl.setHealthDrop(HealthDropPrefab);
        enemyDropControl.HealthDropChance = HealthDropChance;
        enemyDropControl.dropForce = dropForce;
    }

    
}

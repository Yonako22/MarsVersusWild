using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject claude;
    public GameObject robert;
    public GameObject tony;
    private float enemyToSpawn;
    private int placeToSpawn;
    public float spawnCooldown;
    public List<GameObject> spawns = new List<GameObject>();
    public GameManager gameManager;

    private void Start()
    {
        StartCoroutine(Spawn());
        spawnCooldown = 4f;
    }

    private void Update()
    {
        SpawnTime();
    }

    private IEnumerator Spawn()
    {
        enemyToSpawn = Random.Range(1, 4);
        placeToSpawn = Random.Range(0, 13);
        Debug.Log(enemyToSpawn);
        Debug.Log(placeToSpawn);
        yield return new WaitForEndOfFrame();

        if (enemyToSpawn == 1)
        {
            Instantiate(claude, spawns[placeToSpawn].transform.position, Quaternion.identity);
        }

        if (enemyToSpawn == 2)
        {
            Instantiate(robert, spawns[placeToSpawn].transform.position, Quaternion.identity);
        }
        
        if (enemyToSpawn == 3)
        {
            Instantiate(tony, spawns[placeToSpawn].transform.position, Quaternion.identity);
        }
        
        yield return new WaitForSeconds(spawnCooldown);
        StartCoroutine(Spawn());
    }

    void SpawnTime()    //Pour accélérer le spawn des ennemis quand on aura un timer
    { 
        if (gameManager.totalTime > 12)
        {
            spawnCooldown = 6f;
        }
        
        if (gameManager.totalTime > 30)
        {
            spawnCooldown = 5f;
        }
        
        if (gameManager.totalTime > 60)
        {
            spawnCooldown = 4f;
        }
        
        if (gameManager.totalTime > 120)
        {
            spawnCooldown = 3f;
        }
        
        if (gameManager.totalTime > 180)
        {
            spawnCooldown = 2.5f;
        }
        
        if (gameManager.totalTime > 240)
        {
            spawnCooldown = 2f;
        }
    }
}

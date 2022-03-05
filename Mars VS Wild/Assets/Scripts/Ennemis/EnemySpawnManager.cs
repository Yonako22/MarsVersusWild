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

    void SpawnTime()
    { 
        // if (totalTime > 12secondes)
        // {
        //     spawnCooldown = 2f;
        // }
        //
        // if (totalTime > 30secondes)
        // {
        //     spawnCooldown = 2f;
        // }
        //
        // if (totalTime > 1minute)
        // {
        //     spawnCooldown = 1.5f;
        // }
        //
        // if (totalTime > 2minutes)
        // {
        //     spawnCooldown = 1f;
        // }
        //
        // if (totalTime > 3minutes)
        // {
        //     spawnCooldown = 0.5f;
        // }
        //
        // if (totalTime > 4minutes)
        // {
        //     spawnCooldown = 0.3f;
        // }
    }
}

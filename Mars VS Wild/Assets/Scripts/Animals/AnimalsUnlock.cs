using System;
using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalsUnlock : MonoBehaviour
{
    public GameManager gameManager;
    public EnemySpawnManager enemiesSpawn;
    private int placeToSpawn;
    public bool giraffeSpawned;
    public bool gorillaSpawned;
    public bool rhinoSpawned;
    public GameObject giraffe;
    public GameObject gorilla;
    public GameObject rhino;

    void Update()
    {
        if (gameManager.totalTime > 45 && !giraffeSpawned)
        {
            placeToSpawn = Random.Range(0, 14);
            Instantiate(giraffe, enemiesSpawn.spawns[placeToSpawn].transform.position, Quaternion.identity);
            giraffeSpawned = true;
        }
        
        if (gameManager.totalTime > 90 && !gorillaSpawned)
        {
            placeToSpawn = Random.Range(0, 14);
            Instantiate(gorilla, enemiesSpawn.spawns[placeToSpawn].transform.position, Quaternion.identity);
            gorillaSpawned = true;
        }
        
        if (gameManager.totalTime > 90 && !rhinoSpawned)
        {
            placeToSpawn = Random.Range(0, 14);
            Instantiate(rhino, enemiesSpawn.spawns[placeToSpawn].transform.position, Quaternion.identity);
            rhinoSpawned = true;
        }
    }
}

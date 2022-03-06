using System.Collections;
using System.Collections.Generic;
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
        enemyToSpawn = Random.Range(0, 2);
        placeToSpawn = Random.Range(0, 13);
        yield return new WaitForEndOfFrame();

        if (enemyToSpawn == 0)
        {
            Instantiate(claude, spawns[placeToSpawn].transform.position, Quaternion.identity);
        }

        if (enemyToSpawn == 1)
        {
            Instantiate(robert, spawns[placeToSpawn].transform.position, Quaternion.identity);
        }
        
        if (enemyToSpawn == 2)
        {
            Instantiate(tony, spawns[placeToSpawn].transform.position, Quaternion.identity);
        }
        
        yield return new WaitForSeconds(spawnCooldown);
        StartCoroutine(Spawn());
    }

    void SpawnTime()    //Pour accélérer le spawn des ennemis quand on aura un timer
    { 
        if (GameManager.instance.totalTime > 12)
        {
            spawnCooldown = 6f;
        }
        if (GameManager.instance.totalTime > 30)
        {
            spawnCooldown = 4.5f;
        }
        if (GameManager.instance.totalTime > 60)
        {
            spawnCooldown = 3.5f;
        }
        if (GameManager.instance.totalTime > 120)
        {
            spawnCooldown = 2.5f;
        }
        if (GameManager.instance.totalTime > 180)
        {
            spawnCooldown = 1.5f;
        }
        if (GameManager.instance.totalTime > 240)
        {
            spawnCooldown = 1f;
        }
    }
}

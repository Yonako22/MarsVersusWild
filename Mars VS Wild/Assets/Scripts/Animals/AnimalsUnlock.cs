using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsUnlock : MonoBehaviour
{
    public GameManager gameManager;
    public EnemySpawnManager enemiesSpawn;
    private int placeToSpawn;
    public bool giraffeUnlocked;
    public bool gorillaUnlocked;
    public bool rhinoUnlocked;
    public GameObject giraffe;
    public GameObject gorilla;
    public GameObject rhino;

    void Start()
    {
        
    }

    void Update()
    {
        if (gameManager.totalTime > 45 && !giraffeUnlocked)
        {
            placeToSpawn = Random.Range(0, 14);
            Instantiate(giraffe, enemiesSpawn.spawns[placeToSpawn].transform.position, Quaternion.identity);
            giraffeUnlocked = true;
        }
        
        if (gameManager.totalTime > 90 && !gorillaUnlocked)
        {
            placeToSpawn = Random.Range(0, 14);
            Instantiate(gorilla, enemiesSpawn.spawns[placeToSpawn].transform.position, Quaternion.identity);
            gorillaUnlocked = true;
        }
        
        if (gameManager.totalTime > 90 && !rhinoUnlocked)
        {
            placeToSpawn = Random.Range(0, 14);
            Instantiate(rhino, enemiesSpawn.spawns[placeToSpawn].transform.position, Quaternion.identity);
            gorillaUnlocked = true;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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

    void Update()
    {
        if (gameManager.totalTime > 45 && !giraffeUnlocked)
        {
            placeToSpawn = Random.Range(0, 14);
            Instantiate(giraffe, enemiesSpawn.spawns[placeToSpawn].transform.position, Quaternion.identity);
            giraffe.GetComponent<GirafeAttack>().enabled = false;
            giraffe.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 150);
            giraffeUnlocked = true;
        }
        
        if (gameManager.totalTime > 90 && !gorillaUnlocked)
        {
            placeToSpawn = Random.Range(0, 14);
            Instantiate(gorilla, enemiesSpawn.spawns[placeToSpawn].transform.position, Quaternion.identity);
            gorilla.GetComponent<GorilleAttack>().enabled = false;
            gorilla.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 150);
            gorillaUnlocked = true;
        }
        
        if (gameManager.totalTime > 90 && !rhinoUnlocked)
        {
            placeToSpawn = Random.Range(0, 14);
            Instantiate(rhino, enemiesSpawn.spawns[placeToSpawn].transform.position, Quaternion.identity);
            rhino.GetComponent<RhinoAttack>().enabled = false;
            rhino.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 150);
            gorillaUnlocked = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (giraffeUnlocked && col.gameObject.CompareTag("Shelter"))
        {
            //Déverouiller la girafe dans le menu puis détruire le gameobject
        }
        
        if (gorillaUnlocked && col.gameObject.CompareTag("Shelter"))
        {
            //Déverouiller le gorille dans le menu puis détruire le gameobject
        }
        
        if (rhinoUnlocked && col.gameObject.CompareTag("Shelter"))
        {
            //Déverouiller le gorille dans le menu puis détruire le gameobject
        }
    }
}

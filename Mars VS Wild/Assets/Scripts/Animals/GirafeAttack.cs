using System;
using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;

public class GirafeAttack : MonoBehaviour
{
    #region Variables
    [SerializeField] private int damage; //Dégâts de l'animal
    public Animator animator;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public bool giraffeUnlocked;
    public AnimalsUnlock animalsUnlock;
    public UIManager ui;
    
    #endregion


    private void Start()
    {
        animalsUnlock = GameObject.Find("GameManager").GetComponent<AnimalsUnlock>();
        ui = GameObject.Find("GameManager").GetComponent<UIManager>();
        StartCoroutine(Attack());
    }

    private void Update()
    {
        if (animalsUnlock.giraffeSpawned)
        {
            FirstSpawn();
        }
    }

    private void FirstSpawn()
    {
        bc.enabled = false;
        rb.velocity = new Vector2(0, -2f);
    }
    
    private IEnumerator Attack()
    {
        if (giraffeUnlocked)
        {
            animator.SetBool("Attacking", true);
            yield return new WaitForSeconds(0.5f);
            animator.SetBool("Attacking", false);
            bc.enabled = false;
            rb.velocity = new Vector2(0, 3);
            Destroy(gameObject, 10);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (animalsUnlock.giraffeSpawned && other.gameObject.CompareTag("Shelter"))
        {
            animalsUnlock.giraffeSpawned = false;
            giraffeUnlocked = true;
            ui.GirafAvailable = true;
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("hit");
            other.gameObject.GetComponent<Enemies>().hp -= damage;
            other.transform.position = new Vector2(other.transform.position.x, other.transform.position.y + 2);
        }
    }
    
}
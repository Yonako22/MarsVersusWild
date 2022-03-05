using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirafeAttack : MonoBehaviour
{
    #region Variables
    
    public Enemies enemies; //Script des ennemis

    [SerializeField] private List<GameObject> enemiesHit = new List<GameObject>(); //Stocke les ennemis déjà touchés

    [SerializeField] private int damage; //Dégâts de l'animal
    public Animator animator;
    public Rigidbody2D rb;
    
    #endregion


    private void Start()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        animator.SetBool("Attacking", true);
        yield return new WaitForSeconds(0.31f);
        animator.SetBool("Attacking", false);
        rb.velocity = new Vector2(0, 150);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     if (other.CompareTag("Enemy") && !enemiesHit.Contains(other.gameObject))
    //     {
    //         //enemies = other.gameObject.GetComponent<Enemies>();
    //         //enemies.hp -= damage;
    //         enemiesHit.Add(other.gameObject);
    //         Debug.Log("Dégâts");
    //     }
    // }
    
    //Les ennemis doivent avoir un BoxCollider2D, un Rigidbody2D et avoir le Tag "Enemy"
}
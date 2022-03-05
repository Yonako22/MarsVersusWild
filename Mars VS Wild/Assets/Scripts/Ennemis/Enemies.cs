using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float damage;
    public float attackCooldown;
    public float hp;
    public GameObject buildingAttacked;


    private void Update()
    {
        rb.velocity = new Vector2(0, -(speed * Time.deltaTime));

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Building"))
        {
            StartCoroutine(Attack());
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Building"))
        {
            StopCoroutine(Attack());
            buildingAttacked = other.gameObject;
        }
    }

    private IEnumerator Attack()
    {
        //buildingAttacked.GetComponent<BuildingManager>().buildingLife -= damage;
        yield return new WaitForSeconds(attackCooldown);
    }
}

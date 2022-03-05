using System.Collections;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float damage;
    public float attackCooldown;
    public float hp;
    public GameObject buildingAttacked;
    private Buildings buildings;


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
        buildingAttacked = other.gameObject;
        buildings = buildingAttacked.GetComponent<Buildings>();
        
        if (other.gameObject.CompareTag("Building"))
        {
            StartCoroutine(Attack());
        }

        if (other.gameObject.CompareTag("Shelter"))
        {
            StartCoroutine(AttackShelter());
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Building"))
        {
            StopCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        buildings.buildingHP -= damage;
        yield return new WaitForSeconds(attackCooldown);
        StartCoroutine(Attack());
    }

    private IEnumerator AttackShelter()
    {
        buildings.buildingHP -= damage;
        Destroy(gameObject);
        yield return new WaitForEndOfFrame();
    }
}

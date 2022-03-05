using System.Collections.Generic;
using UnityEngine;

public class GirafeAttack : MonoBehaviour
{
    #region Variables
    
    public Enemies enemies; //Script des ennemis

    [SerializeField] private List<GameObject> enemiesHit = new List<GameObject>(); //Stocke les ennemis déjà touchés

    [SerializeField] private int damage; //Dégâts de l'animal
    
    #endregion
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !enemiesHit.Contains(other.gameObject))
        {
            //enemies = other.gameObject.GetComponent<Enemies>();
            //enemies.hp -= damage;
            enemiesHit.Add(other.gameObject);
            Debug.Log("Dégâts");
        }
    }
    
    //Les ennemis doivent avoir un BoxCollider2D, un Rigidbody2D et avoir le Tag "Enemy"
}
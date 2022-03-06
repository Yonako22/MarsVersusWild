using System.Collections;
using Manager;
using UnityEngine;

namespace Animals
{
    public class RhinoAttack : MonoBehaviour
    {
        #region Variables
        [SerializeField] private int damage; //Dégâts de l'animal
        public Animator animator;
        public Rigidbody2D rb;
        public BoxCollider2D bc;
        public AnimalsUnlock animalsUnlock;
        public UIManager ui;
    
        #endregion


        private void Start()
        {
            animalsUnlock = GameObject.Find("GameManager").GetComponent<AnimalsUnlock>();
            ui = GameObject.Find("UI").GetComponent<UIManager>();
            StartCoroutine(Attack());
        }
        
         private void Update()
         {
             if (animalsUnlock.rhinoSpawned)
             {
                 FirstSpawn();
             }
         }

        private void FirstSpawn()
        {
            rb.velocity = new Vector2(0, -2f);
        }
    
        private IEnumerator Attack()
        {
            if (animalsUnlock.rhinoUnlocked)
            {
                animator.SetBool("Attacking", true);
                bc.enabled = false;
                rb.AddForce(new Vector2(0, -12f), ForceMode2D.Force);
                yield return new WaitForSeconds(1f);
                bc.enabled = true;
                rb.velocity = new Vector2(0, 10);
                Destroy(gameObject, 5);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (animalsUnlock.rhinoSpawned && other.gameObject.CompareTag("Shelter"))
            {
                animalsUnlock.rhinoSpawned = false;
                animalsUnlock.rhinoUnlocked = true;
                ui.rhinoAvailable = true;
                Destroy(gameObject);
            }

            if (animalsUnlock.rhinoUnlocked && other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("hit");
                other.gameObject.GetComponent<Enemies>().hp -= damage;
            }
        }
    
    }
}
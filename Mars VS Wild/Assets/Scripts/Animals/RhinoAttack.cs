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
        public GameObject dash;
        public GameObject dash2;
        public AnimalsUnlock animalsUnlock;
        public UIManager ui;

        #endregion


        private void Start()
        {
            animalsUnlock = GameObject.Find("AnimalManager").GetComponent<AnimalsUnlock>();
            ui = GameObject.Find("UI").GetComponent<UIManager>();
            dash.SetActive(false);
            dash2.SetActive(false);
            StartCoroutine(Attack());
        }
        
         private void Update()
         {
             dash.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
             dash2.transform.position = transform.position;
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
                yield return new WaitForSeconds(0.7f);
                dash2.SetActive(true);
                yield return new WaitForSeconds(0.3f);
                dash.SetActive(true);
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
                Destroy(gameObject);
            }

            if (animalsUnlock.rhinoUnlocked && other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Enemies>().hp -= damage;
            }
        }
    
    }
}
using System.Collections;
using Manager;
using UnityEngine;

namespace Animals
{
    public class GorilleAttack : MonoBehaviour
    {
        #region Variables
        [SerializeField] private int damage; //Dégâts de l'animal
        public Animator animator;
        public Rigidbody2D rb;
        public BoxCollider2D bc;
        public bool gorillaUnlocked;
        public AnimalsUnlock animalsUnlock;
        public UIManager ui;
    
        #endregion


        private void Start()
        {
            animalsUnlock = GameObject.Find("GameManager").GetComponent<AnimalsUnlock>();
            ui = GameObject.Find("GameManager").GetComponent<UIManager>();
            StartCoroutine(Attack());
        }

        public void Update()
        {
            if (animalsUnlock.gorillaSpawned)
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
            if (!animalsUnlock.gorillaSpawned)
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
            if (animalsUnlock.gorillaSpawned && other.gameObject.CompareTag("Shelter"))
            {
                animalsUnlock.gorillaSpawned = false;
                gorillaUnlocked = true;
                ui.monkeyAvailable = true;
                Destroy(gameObject);
            }

            if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("hit");
                other.gameObject.GetComponent<Enemies>().hp -= damage;
            }
        }
    
    }
}
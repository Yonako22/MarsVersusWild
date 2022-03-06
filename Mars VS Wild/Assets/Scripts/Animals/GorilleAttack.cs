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
        public AnimalsUnlock animalsUnlock;
        public UIManager ui;
    
        #endregion


        private void Start()
        {
            animalsUnlock = GameObject.Find("GameManager").GetComponent<AnimalsUnlock>();
            ui = GameObject.Find("UI").GetComponent<UIManager>();
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
            rb.velocity = new Vector2(0, -2f);
            bc.size = new Vector2(1, 1);
        }
    
        private IEnumerator Attack()
        {
            if (animalsUnlock.gorillaUnlocked)
            {
                bc.size = new Vector2(3, 3);
                animator.SetBool("Attacking", true);
                rb.velocity = new Vector2(3, 3);
                yield return new WaitForSeconds(0.1f);
                bc.enabled = false;
                yield return new WaitForSeconds(0.6f);
                bc.enabled = true;
                rb.velocity = new Vector2(-3, 3);
                yield return new WaitForSeconds(0.1f);
                bc.enabled = false;
                yield return new WaitForSeconds(0.6f);
                bc.enabled = true;
                rb.velocity = new Vector2(3, 3);
                yield return new WaitForSeconds(0.1f);
                bc.enabled = false;
                yield return new WaitForSeconds(0.6f);
                bc.enabled = true;
                rb.velocity = new Vector2(-3, 3);
                yield return new WaitForSeconds(0.1f);
                bc.enabled = false;
                Destroy(gameObject, 10);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (animalsUnlock.gorillaSpawned && other.gameObject.CompareTag("Shelter"))
            {
                animalsUnlock.gorillaSpawned = false;
                animalsUnlock.gorillaUnlocked = true;
                ui.monkeyAvailable = true;
                Destroy(gameObject);
            }

            if (animalsUnlock.gorillaUnlocked && other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("hit");
                other.gameObject.GetComponent<Enemies>().hp -= damage;
            }
        }
    
    }
}
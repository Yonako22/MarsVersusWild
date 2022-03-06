using System.Collections;
using Manager;
using UnityEngine;

namespace Animals
{
    public class PerroquetAttack : MonoBehaviour
    {
        #region Variables
        [SerializeField] private int damage; //Dégâts de l'animal
        public Animator animator;
        public Rigidbody2D rb;
        public BoxCollider2D bc;
        private int placeToGo;
        public AnimalsUnlock animalsUnlock;
        public UIManager ui;
    
        #endregion
        
        private void Start()
        {
            animalsUnlock = GameObject.Find("AnimalManager").GetComponent<AnimalsUnlock>();
            ui = GameObject.Find("UI").GetComponent<UIManager>();
            StartCoroutine(Attack());
        }
       
        private IEnumerator Attack()
        {
            animator.SetBool("Attacking", true);
            yield return new WaitForSeconds(0.66f);
            animator.SetBool("Attacking", false);
            placeToGo = Random.Range(0, 13);
            bc.enabled = false;
            rb.velocity = new Vector2(0.8f * animalsUnlock.enemiesSpawn.spawns[placeToGo].transform.position.x,
                 0.8f * animalsUnlock.enemiesSpawn.spawns[placeToGo].transform.position.y);
            
            Destroy(gameObject, (5));
            yield return new WaitForEndOfFrame();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Enemies>().hp -= damage;
            }
        }
    }
}
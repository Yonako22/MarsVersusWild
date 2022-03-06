using System;
using System.Collections;
using Animals;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class AnimalManager : MonoBehaviour
{
    public static AnimalManager instance;
    public AnimalsUnlock animalsUnlock;

    public GameObject animalToSpawn;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Il existe deux singletons de AnimalAttacks");
            return;
        }
        instance = this;

        animalsUnlock = gameObject.GetComponent<AnimalsUnlock>();
    }

    #region Variables

    [Header("Bindings")] 
    [SerializeField] private KeyCode perroquet;
    [SerializeField] private KeyCode girafe;
    [SerializeField] private KeyCode gorille;
    [SerializeField] private KeyCode rhino;

    [Header("Prefabs")]
    [SerializeField] private GameObject prefabPerroquet;
    [SerializeField] private GameObject prefabGirafe;
    [SerializeField] private GameObject prefabGorille;
    [SerializeField] private GameObject prefabRhino;

    [Header("Cooldowns")] 
    public int perroquetCD;
    public int girafeCD;
    public int gorilleCD;
    public int rhinoCD;

    public float perroquetCounter;
    public float girafeCounter;
    public float gorilleCounter;
    public float rhinoCounter;

    public bool cooldown1 = true;
    public bool cooldown2 = true;
    public bool cooldown3 = true;
    public bool cooldown4 = true;

    public Image perroquetImage;
    public Image girafeImage;
    public Image gorilleImage;
    public Image rhinoImage;


    [Header("TemporaryVariable")] public GameObject summonedAnimal; //Stocke le dernier animal invoqué pour le détruire

    private int animalSlot = 4; //Permet d'invoquer l'animal sélectionné

    private bool canSummon = true; //Empêche le spam d'animaux tant que celui d'avant est toujours actif

    #endregion

    private void Start()
    {
        perroquetCD = 10;
        girafeCD = 20;
        gorilleCD = 40; 
        rhinoCD = 50;
    }

    void Update()
    {
        #region Réduction des Cooldown

        perroquetImage.fillAmount = ((perroquetCounter - 10) * -10) / 100;
        
        girafeImage.fillAmount = ((girafeCounter - 20) * -5f) / 100f;
        gorilleImage.fillAmount = ((gorilleCounter - 40f) * -2.5f) / 100f;
        rhinoImage.fillAmount = ((rhinoCounter - 50) * 2f) /100;

        if (perroquetCounter > 0 && cooldown1)
        {
            StartCoroutine(Cooldown1());
        }

        if (girafeCounter > 0 && cooldown2)
        {
            StartCoroutine(Cooldown2());
        }

        if (gorilleCounter > 0  && cooldown3)
        {
            StartCoroutine(Cooldown3());
        }

        if (rhinoCounter > 0  && cooldown4)
        {
            StartCoroutine(Cooldown4());
        }
        #endregion
    }
    public GameObject GetAnimalToSpawn()
    {
        return animalToSpawn;
    }
    
    public void callPerroquet()
    {
        if (perroquetCounter <= 0)
        {
            GameManager.instance.gonnaBuild = false;
            GameManager.instance.gonnaSpawn = true;
            animalToSpawn = prefabPerroquet;
           //  Perroquet();
             perroquetCounter = perroquetCD;
        }
    }

    public void callGirafe()
    {
        if (girafeCounter <= 0 && animalsUnlock.giraffeUnlocked)
        {
            GameManager.instance.gonnaBuild = false;
            GameManager.instance.gonnaSpawn = true;
            animalToSpawn = prefabGirafe;
            girafeCounter = girafeCD;
        }
    }

    public void callGorille()
    {
        if (gorilleCounter <= 0 && animalsUnlock.gorillaUnlocked)
        {
            GameManager.instance.gonnaBuild = false;
            GameManager.instance.gonnaSpawn = true;
            animalToSpawn = prefabGorille;
            gorilleCounter = gorilleCD;
        }
    }

    public void callRhino()
    {
        if (rhinoCounter <= 0 && animalsUnlock.rhinoUnlocked)
        {
            GameManager.instance.gonnaBuild = false;
            GameManager.instance.gonnaSpawn = true;
            animalToSpawn = prefabRhino;
            rhinoCounter = rhinoCD;
        }
    }

    #region Appel de l'invocation de l'animal

    void Perroquet()
    {
        SummonAnimal(prefabPerroquet, Vector3.zero, Quaternion.identity, 0.5f);
    }

    void Girafe()
    {
        SummonAnimal(prefabGirafe, Vector3.zero, Quaternion.identity, 1.5f);
    }

    void Gorille()
    {
        SummonAnimal(prefabGorille, Vector3.zero, Quaternion.identity, 3f);
    }

    void Rhino()
    {
        SummonAnimal(prefabRhino, Vector3.zero, Quaternion.identity, 2f);
    }

    #endregion

    #region Invocation et Destruction

    //Invoque l'animal selon les paramètres définis
    void SummonAnimal(GameObject _animal, Vector3 _position, Quaternion _quaternion, float _time)
    {
        summonedAnimal = Instantiate(_animal, _position, _quaternion);
        StartCoroutine(DestroyAnimal(_time));
        canSummon = false;
    }

    //Détruit l'animal après le temps défini
    IEnumerator DestroyAnimal(float _time)
    {
        yield return new WaitForSeconds(_time);
        Destroy(summonedAnimal);
        canSummon = true;
    }

    #endregion

    #region Coroutines
    
    IEnumerator Cooldown1()
    {
        cooldown1 = false;
        perroquetCounter -= 1;
        yield return new WaitForSeconds(1f);
        cooldown1 = true;
    }
    IEnumerator Cooldown2()
    {
        cooldown2 = false;
        girafeCounter -= 1;
        yield return new WaitForSeconds(1f);
        cooldown2 = true;
    }
    IEnumerator Cooldown3()
    {
        cooldown3 = false;
        gorilleCounter -= 1;
        yield return new WaitForSeconds(1f);
        cooldown3 = true;
    }
    IEnumerator Cooldown4()
    {
        cooldown4 = false;
        rhinoCounter -= 1;
        yield return new WaitForSeconds(1f);
        cooldown4 = true;
    }
    
    #endregion
}

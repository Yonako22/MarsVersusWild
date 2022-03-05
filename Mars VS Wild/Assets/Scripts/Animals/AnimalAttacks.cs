using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class AnimalAttacks : MonoBehaviour
{
    public static AnimalAttacks instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Il existe deux singletons de AnimalAttacks");
            return;
        }
        instance = this;
    }

    #region Variables

    [Header("Bindings")] 
    [SerializeField] private KeyCode perroquet;
    [SerializeField] private KeyCode girafe;
    [SerializeField] private KeyCode gorille;
    [SerializeField] private KeyCode rhino;

    [Header("Images")] 
    [SerializeField] private Image perroquetImage;
    [SerializeField] private Image girafeImage;
    [SerializeField] private Image gorilleImage;
    [SerializeField] private Image rhinoImage;

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

    public int perroquetCounter;
    public int girafeCounter;
    public int gorilleCounter;
    public int rhinoCounter;

    public bool cooldown1 = true;
    public bool cooldown2 = true;
    public bool cooldown3 = true;
    public bool cooldown4 = true;

    [Header("TemporaryVariable")] public GameObject summonedAnimal; //Stocke le dernier animal invoqué pour le détruire

    private int animalSlot = 4; //Permet d'invoquer l'animal sélectionné

    private bool canSummon = true; //Empêche le spam d'animaux tant que celui d'avant est toujours actif

    #endregion
    
    void Update()
    {
        #region Inputs et UI

        if (Input.GetKeyDown(perroquet) || Input.GetKeyDown(girafe) || Input.GetKeyDown(gorille) ||
            Input.GetKeyDown(rhino))
        {
            perroquetImage.color = girafeImage.color = gorilleImage.color = rhinoImage.color = Color.white;

            if (Input.GetKeyDown(perroquet))
            {
                perroquetImage.color = Color.green;
                animalSlot = 0;
            }

            if (Input.GetKeyDown(girafe))
            {
                girafeImage.color = Color.green;
                animalSlot = 1;
            }

            if (Input.GetKeyDown(gorille))
            {
                gorilleImage.color = Color.green;
                animalSlot = 2;
            }

            if (Input.GetKeyDown(rhino))
            {
                rhinoImage.color = Color.green;
                animalSlot = 3;
            }
        }

        //Choix de l'animal sélectionné
        if (Input.GetKeyDown(KeyCode.Mouse0) && animalSlot != 4 && canSummon)
        {

            if (animalSlot == 0 && perroquetCounter <= 0)
            {
                Perroquet();
                perroquetCounter = perroquetCD;
            }

            else if (animalSlot == 1 && girafeCounter <= 0)
            {
                Girafe();
                girafeCounter = girafeCD;
            }

            else if (animalSlot == 2 && gorilleCounter <= 0)
            {
                Gorille();
                gorilleCounter = gorilleCD;
            }

            else if (animalSlot == 3 && rhinoCounter <= 0)
            {
                Rhino();
                rhinoCounter = rhinoCD;
            }
        }

        #endregion
        
        #region Réduction des Cooldown

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

    #region Appel de l'invocation de l'animal

    void Perroquet()
    {
        SummonAnimal(prefabPerroquet, Vector3.zero, Quaternion.identity, 0.5f, new Vector2(1, 1));
    }

    void Girafe()
    {
        SummonAnimal(prefabGirafe, Vector3.zero, Quaternion.identity, 1.5f, new Vector2(1, 6));
    }

    void Gorille()
    {
        SummonAnimal(prefabGorille, Vector3.zero, Quaternion.identity, 3f, new Vector2(3, 3));
    }

    void Rhino()
    {
        SummonAnimal(prefabRhino, Vector3.zero, Quaternion.identity, 2f, new Vector2(3, 1));
    }

    #endregion

    #region Invocation et Destruction

    //Invoque l'animal selon les paramètres définis
    void SummonAnimal(GameObject _animal, Vector3 _position, Quaternion _quaternion, float _time, Vector2 _size)
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

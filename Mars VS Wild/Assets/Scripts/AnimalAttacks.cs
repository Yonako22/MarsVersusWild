using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimalAttacks : MonoBehaviour
{
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

    [Header("TemporaryVariable")]
    public GameObject summonedAnimal; //Stocke le dernier animal invoqué pour le détruire
    
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

            if (animalSlot == 0)
            {
                Perroquet();
            }
            
            else if (animalSlot == 1)
            {
                Girafe();
            }
            
            else if (animalSlot == 2)
            {
                Gorille();
            }
            
            else if (animalSlot == 3)
            {
                Rhino();
            }
        }
        
        #endregion
    }

    #region Appel de l'invocation de l'animal
    
    void Perroquet()
    {
        SummonAnimal(prefabPerroquet, Vector3.zero, Quaternion.identity, 0.5f, new Vector2(1,1));
    }

    void Girafe()
    {
        SummonAnimal(prefabGirafe, Vector3.zero, Quaternion.identity, 1.5f, new Vector2(1,6));
    }

    void Gorille()
    {
        SummonAnimal(prefabGorille, Vector3.zero, Quaternion.identity, 3f, new Vector2(3,3));
    }

    void Rhino()
    {
        SummonAnimal(prefabRhino, Vector3.zero, Quaternion.identity, 2f, new Vector2(3,1));
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
}

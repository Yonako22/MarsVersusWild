using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimalAttacks : MonoBehaviour
{
    [SerializeField] private KeyCode perroquet;
    [SerializeField] private KeyCode girafe;
    [SerializeField] private KeyCode gorille;
    [SerializeField] private KeyCode rhino;

    [SerializeField] private Image perroquetImage;
    [SerializeField] private Image girafeImage;
    [SerializeField] private Image gorilleImage;
    [SerializeField] private Image rhinoImage;

    [SerializeField] private GameObject prefabPerroquet;
    [SerializeField] private GameObject prefabGirafe;
    [SerializeField] private GameObject prefabGorille;
    [SerializeField] private GameObject prefabRhino;

    private int animalSlot = 4;

    public GameObject summonedAnimal;

    private bool canSummon = true;
    void Update()
    {
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
        //Sélection de l'animal

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
    }

    void Perroquet()
    {
        summonedAnimal = Instantiate(prefabPerroquet, Vector3.zero, Quaternion.identity);
        StartCoroutine(DestroyAnimal(0.5f));
        canSummon = false;
    }

    void Girafe()
    {
        
    }

    void Gorille()
    {
        
    }

    void Rhino()
    {
        
    }

    IEnumerator DestroyAnimal(float _time)
    {
        yield return new WaitForSeconds(_time);
        Destroy(summonedAnimal);
        canSummon = true;
    }
}

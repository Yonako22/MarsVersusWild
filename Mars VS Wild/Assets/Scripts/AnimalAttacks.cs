using System.Management.Instrumentation;
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

    private int animalSlot;
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
    }
}

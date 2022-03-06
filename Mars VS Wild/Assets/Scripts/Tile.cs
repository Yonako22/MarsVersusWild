using Manager;
using Unity.Mathematics;
using UnityEngine;
 
public class Tile : MonoBehaviour 
{
    [SerializeField] private GameObject _highlight;
    
    public GameObject building;
    public Buildings buildingScript;

    public GameObject animal;
    public AnimalManager animalManager;

    private void Start()
    {
        _highlight.SetActive(false);
    }
    
    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    private void OnMouseDown()
    {
        if (!UIManager.instance.isPaused)
        {
            GameObject buildingToBuild = BuildingManager.instance.GetBuildingToBuild();

            if (GameManager.instance.gonnaUpgrade)
            {
                buildingScript = building.GetComponent<Buildings>();

                if (building != null && buildingScript.canBeUpgrade)
                {
                    
                    if (building.gameObject.GetComponent<Buildings>().buildingLevel == 1)
                    {
                        if (GameManager.instance.wood >= buildingToBuild.GetComponent<Buildings>().buildingPriceLvl2)
                        {
                            GameManager.instance.wood -= buildingToBuild.GetComponent<Buildings>().buildingPriceLvl2;
                            buildingScript.buildingLevel +=1;
                        }
                    }
                    if (building.gameObject.GetComponent<Buildings>().buildingLevel == 2)
                    {
                        if (GameManager.instance.wood >= buildingToBuild.GetComponent<Buildings>().buildingPriceLvl3)
                        {
                            GameManager.instance.wood -= buildingToBuild.GetComponent<Buildings>().buildingPriceLvl3;
                            buildingScript.buildingLevel +=1;
                        }
                    }
                    if (building.gameObject.GetComponent<Buildings>().buildingLevel == 3)
                    {
                      Debug.Log("Reach max upgrade");
                    }
                }
            }
            if (GameManager.instance.gonnaBuild)
            {
                
                if (building != null)
                {
                    Debug.Log("Impossible de construire ici, il y a déjà une tourelle.");
                }
                else
                {
                    if (GameManager.instance.wood >= buildingToBuild.GetComponent<Buildings>().buildingPriceLvl1)
                    {
                        building = Instantiate(buildingToBuild, transform.position, quaternion.identity);
                        GameManager.instance.wood -= buildingToBuild.GetComponent<Buildings>().buildingPriceLvl1;
                        GameManager.instance.gonnaBuild = false;
                    }
                    else
                    {
                        Debug.Log("pas assez d'argent");
                    }
                }
            }

            if (GameManager.instance.gonnaSpawn)
            {
                GameObject animalToSpawn = AnimalManager.instance.GetAnimalToSpawn();
                
                animal = Instantiate(animalToSpawn, transform.position, quaternion.identity);
            }
        }
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}
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
            if (GameManager.instance.gonnaBuild)
            {
                if (building != null)
                {
                    buildingScript = building.GetComponent<Buildings>();  
                    if(!buildingScript.canBeUpgrade)
                    {
                        Debug.Log("Impossible de construire ici, il y a déjà une tourelle.");
                        return;
                    }
                                                                        
                    if (buildingScript.canBeUpgrade)
                    {
                        buildingScript.buildingLevel +=1;
                    }
                }
                else
                {
                    GameObject buildingToBuild = BuildingManager.instance.GetBuildingToBuild();
            
                    if (GameManager.instance.wood >= buildingToBuild.GetComponent<Buildings>().buildingPriceLvl1)
                    {
                        building = (GameObject)Instantiate(buildingToBuild, transform.position, quaternion.identity);
                        GameManager.instance.wood -= buildingToBuild.GetComponent<Buildings>().buildingPriceLvl1;
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
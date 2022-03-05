using System;
using Unity.Mathematics;
using UnityEngine;
 
public class Tile : MonoBehaviour 
{
    [SerializeField] private GameObject _highlight;


    public GameObject building;
    public Buildings buildingScript;

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
        if (building != null)
        {
            buildingScript = building.GetComponent<Buildings>();
        }
        Debug.Log(name);
        if(building != null && !buildingScript.canBeUpgrade)
        {
           
            Debug.Log("Impossible de construire ici, il y a déjà une tourelle.");
            return;
        }
        
        if (building != null && buildingScript.canBeUpgrade)
        {
            buildingScript.buildingLevel +=1;
        }

        if (building == null)
        {
        }

        GameObject buildingToBuild = BuildingManager.instance.GetBuildingToBuild();
        building = (GameObject)Instantiate(buildingToBuild, transform.position, quaternion.identity);
        Debug.Log("built");
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}
using System;
using UnityEngine;
 
public class Tile : MonoBehaviour 
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    [SerializeField] private Vector3 positionOffset;

    
    public GameObject building;
    public Buildings buildingScript;
    

    private void Start()
    {
        _highlight.SetActive(false);
        buildingScript = building.GetComponent<Buildings>();
    }

    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }
 
    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    private void OnMouseDown()
    {
        Debug.Log(name);
        if(building != null && !buildingScript.canBeUpgrade)
        {
            Debug.Log("Impossible de construire ici, il y a déjà une tourelle.");
            return;
        }
        else if (building != null && buildingScript.canBeUpgrade)
        {
            // Quand tu touche un batiment qui peut etre upgrade
            buildingScript.buildingLevel +=1;
        }

        GameObject turretToBuild = BuildingManager.instance.GetTurretToBuild();
        building = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}
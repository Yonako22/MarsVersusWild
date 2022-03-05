using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shelter : Buildings
{
    public BuildingManager buildingManager;
    
    void Update()
    {
        if (buildingLevel == 2)
        {
            //buildingManager
        }
        if (buildingLevel == 3)
        {
            //produire 5 ressources toutes les 2 secondes
            canBeUpgrade = false;
        }

        if (buildingHP <= 0)
        {
            Debug.Log("Lose");
        }
    }
}

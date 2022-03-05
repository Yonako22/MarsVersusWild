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
            buildingManager.woodPerSecond = 2;
        }
        if (buildingLevel == 3)
        {
            buildingManager.woodPerSecond = 2.5f;
            canBeUpgrade = false;
        }

        if (buildingHP <= 0)
        {
            Debug.Log("Lose");
        }
    }
}

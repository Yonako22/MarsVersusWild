using UnityEngine;

public class AutoTurret : Buildings
{
    private void Start()
    {
        buildingHP = 30;
        col = gameObject.GetComponent<Collider2D>();
        
        buildingPriceLvl1 =10; // + deux par posé
        buildingPriceLvl2 = 15;
        buildingPriceLvl3 = 15;
        
        buildingLevel = 1;
    }
}
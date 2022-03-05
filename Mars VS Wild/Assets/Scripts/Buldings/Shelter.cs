using System;
using UnityEngine;
using UnityEngine.UI;

public class Shelter : Buildings
{

    public float shelterHealth = 100f;
    public Slider healthBar;
    private void Start()
    {
        buildingHP = 100;
    }

    void Update()
    {
        
        
        if (buildingLevel == 2)
        {
           GameManager.instance.woodPerSecond = 2;
        }
        if (buildingLevel == 3)
        {
            GameManager.instance.woodPerSecond = 2.5f;
            canBeUpgrade = false;
        }

        if (buildingHP <= 0)
        {
            Debug.Log("Lose");
        }
    }
    
    
    
}
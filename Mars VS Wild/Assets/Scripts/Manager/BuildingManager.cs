using System;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager instance;
    public GameObject[] buildings;
    public GameObject turretToBuild;

    public int numberOfAutoTurrets;
    public int numberOfLaserTurrets;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("STOP! building");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        turretToBuild = buildings[0]; // Par défaut
    }

    public void BuildAutoTurret()
    {
        numberOfAutoTurrets++;
        turretToBuild = buildings[0];
    }
    public void BuildLaserTurret()
    {
        numberOfLaserTurrets++;
        turretToBuild = buildings[1];
    }
    public void BuildBarricades() { turretToBuild = buildings[2]; }
    public void BuildInfirmary() { turretToBuild = buildings[3]; }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}

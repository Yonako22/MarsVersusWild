using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager instance;
    public GameObject[] buildings;
    public GameObject buildingToBuild;

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
        buildingToBuild = buildings[0]; // Par défaut
    }

    public void setBuildAutoTurret()
    {
        GameManager.instance.gonnaSpawn = false;
        GameManager.instance.gonnaBuild = true;
        numberOfAutoTurrets++;
        buildingToBuild = buildings[0];
    }
    public void setBuildLaserTurret()
    {
        GameManager.instance.gonnaSpawn = false;
        GameManager.instance.gonnaBuild = true;
        numberOfLaserTurrets++;
        buildingToBuild = buildings[1];
    }

    public void setBuildBarricades()
    {
        GameManager.instance.gonnaSpawn = false;
        GameManager.instance.gonnaBuild = true;
        buildingToBuild = buildings[2];
    }

    public void setBuildInfirmary()
    {
        GameManager.instance.gonnaSpawn = false;
        GameManager.instance.gonnaBuild = true;
        buildingToBuild = buildings[3];
    }

    public GameObject GetBuildingToBuild()
    {
        return buildingToBuild;
    }
}

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
        GameManager.instance.gonnaBuild = true;
        GameManager.instance.gonnaSpawn = false;
        numberOfAutoTurrets++;
        buildingToBuild = buildings[0];
    }
    public void setBuildLaserTurret()
    {
        GameManager.instance.gonnaBuild = true;
        GameManager.instance.gonnaSpawn = false;
        numberOfLaserTurrets++;
        buildingToBuild = buildings[1];
    }

    public void setBuildBarricades()
    {
        GameManager.instance.gonnaBuild = true;
        GameManager.instance.gonnaSpawn = false;
        buildingToBuild = buildings[2];
    }

    public void setBuildInfirmary()
    {
        GameManager.instance.gonnaBuild = true;
        GameManager.instance.gonnaSpawn = false;
        buildingToBuild = buildings[3];
    }

    public GameObject GetBuildingToBuild()
    {
        return buildingToBuild;
    }
}

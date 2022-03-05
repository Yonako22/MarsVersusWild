using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager instance;
    public GameObject[] buildings;
    private GameObject turretToBuild;

    public int numberOfAutoTurrets;
    public int numberOfLaserTurrets;

    public float wood;
    public float woodPerSecond = 1;
    private void Awake()
    {
        wood = 1.5f;
        
        if (instance != null)
        {
            Debug.LogWarning("STOP! building");
            return;
        }

        instance = this;
    }

    private void Update()
    {
        wood += Time.deltaTime * woodPerSecond;
    }

    public void BuildAutoTurret()
    {
        numberOfAutoTurrets++;
        turretToBuild = buildings[0];
        //wood -= 10;
    }
    public void BuildLaserTurret()
    {
        numberOfLaserTurrets++;
        turretToBuild = buildings[1];
        //wood -= 20;
    }

    public void BuildBarricades()
    {
        turretToBuild = buildings[2];
        //wood -= 35;
    }

    public void BuildInfirmary()
    {
        turretToBuild = buildings[3];
        //wood -+ 100;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}

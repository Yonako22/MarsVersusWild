using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager instance;
    public GameObject[] buildings;
    private GameObject turretToBuild;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("STOP! building");
            return;
        }

        instance = this;
    }
    
    public void BuildAutoTurret()
    {
        turretToBuild = buildings[0];
    }
    
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}

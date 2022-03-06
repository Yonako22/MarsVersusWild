using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float totalTime;
    
    public float wood;
    public float woodPerSecond = 2;
    
    public bool gonnaBuild;
    public bool gonnaSpawn;
    public bool gonnaUpgrade;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("STOP! Game");
            return;
        }

        instance = this;
    }

    void Start()
    {
        GridManager.instance.GenerateGrid();
        
        wood = 50;
    }

    private void Update()
    {
        totalTime += Time.deltaTime;

        if (totalTime > 300)
        {
            Debug.Log("Victory");
        }
        
        wood += Time.deltaTime * woodPerSecond;

        if (!gonnaBuild && !gonnaSpawn)
        {
            gonnaUpgrade = true;
        }
        else
        {
            gonnaUpgrade = false;
        }
    }
}
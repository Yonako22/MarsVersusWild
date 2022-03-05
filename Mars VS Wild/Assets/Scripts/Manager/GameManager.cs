using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float totalTime;
    
    public float wood;
    public float woodPerSecond = 1;
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
        
        wood = 1000;
    }

    private void Update()
    {
        totalTime += Time.deltaTime;

        if (totalTime > 300)
        {
            Debug.Log("Victory");
        }
        
        wood += Time.deltaTime * woodPerSecond;
    }
}
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("STOP! Game");
            return;
        }

        instance = this;
    }

    void Start()
    {
        GridManager.instance.GenerateGrid();
    }
}
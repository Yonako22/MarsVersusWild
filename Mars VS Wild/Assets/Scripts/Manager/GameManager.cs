using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float totalTime;

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

    private void Update()
    {
        totalTime += Time.deltaTime;

        if (totalTime > 0.02)
        {
            Debug.Log("dj");
        }
    }
}
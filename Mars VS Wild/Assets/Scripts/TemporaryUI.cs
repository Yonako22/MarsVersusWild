using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryUI : MonoBehaviour
{

    public float wood;
    public float woodPerSecond = 1;

    // Start is called before the first frame update
    void Start()
    {
        wood = 0;
    }

    // Update is called once per frame
    void Update()
    {
        wood += Time.deltaTime * woodPerSecond;
    }
}

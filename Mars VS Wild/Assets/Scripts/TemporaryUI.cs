using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TemporaryUI : MonoBehaviour
{

    public float wood;
    public float woodPerSecond = 1;
    public TextMeshProUGUI woodTxt;
    
    void Start()
    {
        wood = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        wood += Time.deltaTime * woodPerSecond;
        woodTxt.text = " " + (int)wood;
    }
}

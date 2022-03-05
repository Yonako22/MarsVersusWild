/*
using System;
using System.Collections;
using UnityEngine;

public class Soleil : MonoBehaviour
{
    [SerializeField] private Light _light;

    public bool itsMorning,itsAfterrnoon,itsEvening,itsNight;

    private void Start()
    {
        StartCoroutine(cycleJourNuit());
    }

    IEnumerator cycleJourNuit()
    {
        itsEvening = false;
        itsMorning = true;
        yield return new WaitForSeconds(60f);
        itsMorning = false;
        itsAfterrnoon = true;
        yield return new WaitForSeconds(60f);
        itsAfterrnoon = false;
        itsEvening = true;
        yield return new WaitForSeconds(60f);
        itsEvening = false;
        itsNight = true;
        yield return new WaitForSeconds(60f);
        StartCoroutine(cycleJourNuit());
    }
    
    private void Update()
    {
        Debug.Log();
    }
}
*/

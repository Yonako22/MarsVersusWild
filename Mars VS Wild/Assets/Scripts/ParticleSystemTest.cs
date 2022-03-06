using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemTest : MonoBehaviour
{
    public GameObject building;

    public void BuildingDestroyed()
    {
        ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
        GetComponent <ParticleSystem>().Play ();
        em.enabled = true;
        Destroy(building);
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}

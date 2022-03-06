using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemTest : MonoBehaviour
{
    // void Update()
    // {
    //     if (Input.GetKey(KeyCode.Space))
    //     {
    //         GetComponent <ParticleSystem>().Play ();
    //         ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
    //         em.enabled = true;
    //     }
    // }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent <ParticleSystem>().Play ();
        ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
        em.enabled = true;
    }
}

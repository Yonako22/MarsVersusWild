using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfirmerieParticle : MonoBehaviour
{
    void Update()
    {
        ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
        GetComponent <ParticleSystem>().Play ();
        em.enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfirmerieParticle : MonoBehaviour
{
    void Update()
    {
        UnityEngine.ParticleSystem.EmissionModule em = GetComponent<UnityEngine.ParticleSystem>().emission;
        GetComponent <UnityEngine.ParticleSystem>().Play ();
        em.enabled = true;
    }
}

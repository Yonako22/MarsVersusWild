using System.Collections;
using UnityEngine;

public class ParticleSystem : MonoBehaviour
{
    public GameObject building;

    public void BuildingDestroyed()
    {
        UnityEngine.ParticleSystem.EmissionModule em = GetComponent<UnityEngine.ParticleSystem>().emission;
        GetComponent <UnityEngine.ParticleSystem>().Play ();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : Buildings
{
    public float damage;
    public GameObject laser;
    private GameObject laser1;
    private GameObject laser2;
    private GameObject laser3;
    private GameObject laser4;
    public GameObject cannon1;
    public GameObject cannon2;
    public GameObject cannon3;
    public GameObject cannon4;
    public float shootingCooldown;
    
    void Start()
    {
        damage = 10;
        laser1 = Instantiate(laser, cannon1.transform.position, cannon1.transform.rotation);
        laser2 = Instantiate(laser, cannon2.transform.position, cannon2.transform.rotation);
        laser3 = Instantiate(laser, cannon3.transform.position, cannon3.transform.rotation);
        laser4 = Instantiate(laser, cannon4.transform.position, cannon4.transform.rotation);
        laser1.SetActive(false);
        laser2.SetActive(false);
        laser3.SetActive(false);
        laser4.SetActive(false);
        StartCoroutine(Shoot());
    }
    
    void Update()
    {
        Upgrade();
        if (buildingHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(shootingCooldown);
        laser1.SetActive(true);
        laser2.SetActive(true);
        laser3.SetActive(true);
        laser4.SetActive(true);
        yield return new WaitForSeconds(1);
        laser1.SetActive(false);
        laser2.SetActive(false);
        laser3.SetActive(false);
        laser4.SetActive(false);
        StartCoroutine(Shoot());
    }
    
    private void Upgrade()
    {
        if (buildingLevel == 2)
        {
            damage = 15;
        }
        
        if (buildingLevel == 3)
        {
            damage = 20;
        }
    }
}

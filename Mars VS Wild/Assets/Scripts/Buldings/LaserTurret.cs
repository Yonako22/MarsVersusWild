using System.Collections;
using Unity.Mathematics;
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

    private Vector2 _rotation;
    void Start()
    {
        damage = 10;
        buildingHP = 30;

        laser1 = Instantiate(laser, new Vector2(cannon1.transform.position.x, cannon1.transform.position.y), quaternion.identity);
        laser2 = Instantiate(laser, new Vector2(cannon2.transform.position.x, cannon2.transform.position.y), cannon2.transform.rotation);
        laser3 = Instantiate(laser, new Vector2(cannon3.transform.position.x, cannon3.transform.position.y), cannon3.transform.rotation);
        laser4 = Instantiate(laser, new Vector2(cannon4.transform.position.x, cannon4.transform.position.y),cannon4.transform.rotation );
        
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

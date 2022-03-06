using System;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject laserTurret;
    private LaserTurret laserTurretScript;

    private void Awake()
    {
        laserTurretScript = laserTurret.gameObject.GetComponent<LaserTurret>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Debug.Log(col.gameObject.GetComponent<Enemies>().hp);
            Debug.Log(laserTurretScript.damage);
            col.gameObject.GetComponent<Enemies>().hp -= laserTurretScript.damage;
            Debug.Log(col.gameObject.GetComponent<Enemies>().hp);
        }
    }
}
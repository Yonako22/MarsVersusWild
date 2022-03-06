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
            col.gameObject.GetComponent<Enemies>().hp -= laserTurretScript.damage;
        }
    }
}
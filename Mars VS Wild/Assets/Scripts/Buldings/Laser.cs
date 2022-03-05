using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject LaserTurret;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Debug.Log(col.gameObject.GetComponent<Enemies>().hp);
            col.gameObject.GetComponent<Enemies>().hp -= LaserTurret.GetComponent<LaserTurret>().damage;
            Debug.Log(col.gameObject.GetComponent<Enemies>().hp);
        }
    }
}
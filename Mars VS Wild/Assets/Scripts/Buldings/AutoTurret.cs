using UnityEngine;

public class AutoTurret : Buildings
{
    public float attackDamage;
    
    public float fireRateLvl1;
    public float fireRateLvl2;
    public float fireRateLvl3;
    
    private float fireCountdown;
    
    public Transform partToRotate;
    private float turnSpeed;
    
    private Transform target;
    
    public GameObject bulletPrefab;
    public Transform firePoint;
    
    public Vector2 topRightCorner;
    public Vector2 botDownCorner;

    private void Update()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        Collider2D[] enemiesInRange = Physics2D.OverlapBoxAll(col.bounds.center, new Vector2(topRightCorner.x, botDownCorner.y), 0);
        
       foreach (Collider2D col in enemiesInRange)
       {
           float distanceToEnemy = Vector3.Distance(transform.position, col.transform.position);
           
           if(distanceToEnemy < shortestDistance)
           {
               nearestEnemy = col.gameObject;
           }
       }
       
       if(nearestEnemy != null)
       {
           target = nearestEnemy.transform;
       }
       else
       {
           target = null;
       }
       
       if(target == null)
       {
           return;
       }
       
       if (buildingHP <= 0)
       {
           Destroy(gameObject);
       }
       
       Vector3 dir = target.position - transform.position;
       Quaternion lookRotation = Quaternion.LookRotation(dir);
       Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
       partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

       if(fireCountdown <= 0f)
       {
           Shoot();
           fireCountdown = 1 / fireRateLvl1;
       }

       fireCountdown -= Time.deltaTime;
    }
    
    void Shoot()
    {
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        /*Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
        */
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, new Vector2(topRightCorner.x,botDownCorner.y));
    }
}
using UnityEngine;

public class AutoTurret : Buildings
{
    public float fireRateLvl1;
    public float fireRateLvl2;
    public float fireRateLvl3;
    
    private float fireCountdown;
    
    public GameObject bulletPrefab;
    public Transform firePoint;

    public Transform partToRotate;
    [SerializeField] float turnSpeed;
    
    [SerializeField] Transform target;
    
    public float range;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        
        foreach (GameObject enemy in ennemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
           
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    private void Update()
    {
        if(target == null)
        {
           return; 
        }

       Vector3 dir = target.position - transform.position;
       Quaternion lookRotation = Quaternion.LookRotation(dir);
       Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
       partToRotate.rotation = Quaternion.Euler(0f, 0f, rotation.z);
       
       if(fireCountdown <= 0f)
       {
           Shoot();
           fireCountdown = 1 / fireRateLvl1;
       }

       fireCountdown -= Time.deltaTime;
       
       if (buildingHP <= 0)
       {
           Destroy(gameObject);
       }
    }
    
    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
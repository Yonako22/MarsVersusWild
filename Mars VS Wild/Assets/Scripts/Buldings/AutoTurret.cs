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

    public SpriteRenderer _base;
    public SpriteRenderer _cannon;

    public Sprite _baselvl2;
    public Sprite _baselvl3;

    public Sprite _canonLvl2;
    public Sprite _canonLvl3;

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
        if (buildingLevel ==2)
        {
            _base.sprite = _baselvl2;
            _cannon.sprite = _canonLvl2;
        }

        if (buildingLevel ==3)
        {
            _base.sprite = _baselvl3;
            _cannon.sprite = _canonLvl3;
        }
        
        
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
           if (buildingLevel ==1)
           {
               fireCountdown = 1 / fireRateLvl1;
           }
           if (buildingLevel ==2)
           {
               fireCountdown = 1 / fireRateLvl2;
           }
           if (buildingLevel ==3)
           {
               fireCountdown = 1 / fireRateLvl3;
           }
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{


    [Header("Gun Configuration")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private int maxBullets = 30;
    [SerializeField] private int currentBullets;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float fireRate = 0.15f;
    [SerializeField] private float reloadTime = 2f;

    [Header("ObjectPool Configuration")]
    [SerializeField] private int poolSize = 50;

    private bool isShooting;
    private bool isReloading;
    private float nextFireTime;
    private ObjectPool bulletPool;




    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new ObjectPool(bulletPrefab, poolSize);
        currentBullets = maxBullets;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && CanShoot())
        {
            Shoot();
        }
        if (Input.GetMouseButton(1) && isReloading && currentBullets < maxBullets)
        {
            StartCoroutine(Reload());
        }
    }
    bool CanShoot()
    {
        return !isReloading && currentBullets > 0 && Time.time >= nextFireTime;
    }
    void Shoot()
    {
        nextFireTime = Time.time + fireRate;
        GameObject bullet = bulletPool.GetObject();

        if(bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);

            Bullet bulletComponent = bullet.GetComponent<Bullet>();

            if(bulletComponent != null)
            {
                bulletComponent.Shoot(firePoint.forward * bulletSpeed);
            }
            currentBullets--;

        }
       

    }
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Recargando...");

        yield return new WaitForSeconds(reloadTime);
        currentBullets = maxBullets;
        isReloading = false;
        Debug.Log("Recarga Completa...");
    }

    public int GetCurrentBullets() => currentBullets;
    public int GetMaxBullets() => maxBullets;
    public bool IsReloading() => isReloading;
}

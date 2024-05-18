using UnityEngine;
using System.Collections.Generic;

public class FireController : MonoBehaviour
{
    public GameObject projectilePrefab; // Ateş edilecek nesnenin prefab'ı
    public int poolSize = 10; // Havuz boyutu
    public float fireRate = 0.5f; // Ateş hızı
    public Transform firePoint; // Ateş noktası

    public List<GameObject> projectilePool; // Havuzdaki atış nesneleri
    private float nextFireTime; // Sonraki ateş zamanı

    void Start()
    {
        // Ateş nesnelerinin havuzunu oluştur
        InitializePool();
    }

    void Update()
    {
        // Fare sol tuşuna basılı tutulduğu sürece ateş et
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1/(fireRate*FindObjectOfType<Manager>().fireRateMultiplier); // Sonraki ateş zamanını ayarla
        }
    }

    void InitializePool()
    {
        projectilePool = new List<GameObject>(); // Havuz listesini oluştur

        // Belirtilen havuz boyutu kadar atış nesnesi oluştur ve havuza ekle
        for (int i = 0; i < poolSize; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab, Vector3.zero, Quaternion.identity);
            projectile.SetActive(false); // Nesneyi etkisiz hale getir
            projectilePool.Add(projectile); // Nesneyi havuza ekle
        }
    }

    void Shoot()
    {
        // Havuzdan kullanılabilir bir atış nesnesi al
        GameObject projectile = GetPooledProjectile();

        if (projectile != null)
        {
            // Atış noktasında atış nesnesini etkinleştir ve konumunu ayarla
            projectile.SetActive(true);
            projectile.GetComponent<Bullet>().onCall(firePoint);
            projectile.transform.position = firePoint.position;
            projectile.transform.rotation = firePoint.rotation;
        }
    }

    GameObject GetPooledProjectile()
    {
        // Havuzda etkisiz hale getirilmiş bir atış nesnesi ara ve bul
        foreach (GameObject projectile in projectilePool)
        {
            if (!projectile.activeInHierarchy)
            {
                return projectile;
            }
        }

        // Havuzda uygun atış nesnesi bulunamazsa null döndür
        return null;
    }
}

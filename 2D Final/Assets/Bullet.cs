using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageAmount = 1; // Hasar miktarı
    public float bulletSpeed;
    private float disableTimer; // Devre dışı bırakma süresi için sayaç

    public void onCall()
    {
        // Her etkinleştirildiğinde devre dışı bırakma süresini sıfırla
        ResetDisableTimer();
    }

    void Update()
    {
        // Mermi hareketi
        Vector3 bulletDirection = transform.up;
        Vector3 newPosition = transform.position + bulletDirection * bulletSpeed * Time.deltaTime;
        transform.position = newPosition;

        // Devre dışı bırakma süresini güncelle
        disableTimer -= Time.deltaTime;

        // Süre dolduğunda devre dışı bırak
        if (disableTimer <= 0f)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Çarpışan objenin "enemy" tag'ine sahip olup olmadığını kontrol et
        if (other.CompareTag("Enemy"))
        {
            // Düşmana hasar ver
            Manager manager = GameObject.FindWithTag("Manager").GetComponent<Manager>();
            if (manager != null)
            {
                manager.TakeDamage(other.gameObject, damageAmount);
            }

            // Kendisini devre dışı bırak
            gameObject.SetActive(false);
        }
    }

    // Devre dışı bırakma süresini sıfırla
    void ResetDisableTimer()
    {
        disableTimer = 2f;
    }
}

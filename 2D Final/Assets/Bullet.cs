using UnityEngine;

public class Bullet : MonoBehaviour
{
    Manager manager;
    public int damageAmount = 1; // Hasar miktarı
    public float bulletSpeed;
    private float disableTimer; // Devre dışı bırakma süresi için sayaç
    private void Start()
    {
        manager = GameObject.FindWithTag("Manager").GetComponent<Manager>();
    }
    public void onCall(Transform startPos)
    {
        // Her etkinleştirildiğinde devre dışı bırakma süresini sıfırla
        gameObject.GetComponent<Renderer>().enabled=false;
        ResetDisableTimer();
        transform.position = startPos.position;
        gameObject.GetComponent<Renderer>().enabled = true;

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
        if (other.CompareTag("enemy"))
        {
            // Düşmana hasar ver
            
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

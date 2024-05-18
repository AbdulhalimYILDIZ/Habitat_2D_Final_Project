using UnityEngine;

public class Manager : MonoBehaviour
{
    public int damageMultiplier = 1; // Hasar miktarı
    public int hpMultiplier = 100; // Can
    public float moveSpeedMultiplier = 5f; // Hareket hızı
    public float fireRateMultiplier = 0.5f; // Ateş hızı

    void Start()
    {
        // İlgili başlangıç kodlarını buraya ekleyebilirsiniz
    }

    // Düşmana hasar vermek için bir fonksiyon
    public void TakeDamage(GameObject obj, int amount)
    {
        // Hasarı düşmanın canından düşür
        obj.GetComponent<enemy>().hp -= amount;

        // Eğer düşmanın canı 0 veya daha azsa, ölüm fonksiyonunu çağır
        if (obj.GetComponent<enemy>().hp <= 0)
        {
            Die();
        }
    }

    // Düşmanın öldüğü durumda yapılacak işlemler
    void Die()
    {
        // Düşmanın ölümüyle ilgili işlemleri buraya ekleyebilirsiniz
        Debug.Log("Düşman öldü!");

        // Öldüğünde yapılacak işlemler buraya yazılabilir.
    }
}

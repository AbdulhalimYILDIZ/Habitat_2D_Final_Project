using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Manager scriptine erişim için referans
    public Manager manager;

    // ScriptableObject referansı
    public EnemyData enemyData;

    void Update()
    {
        // EnemyData ScriptableObject'ten değerleri al
        int baseDamage = enemyData.damage;
        float baseMoveSpeed = enemyData.moveSpeed;
        int baseHp = enemyData.hp;
        float baseFireRate = enemyData.fireRate;

        // Manager'dan alınan çarpan ile değerleri işleme sok
        int finalDamage = Mathf.RoundToInt(baseDamage * manager.damageMultiplier);
        float finalMoveSpeed = baseMoveSpeed * manager.moveSpeedMultiplier;
        int finalHp = Mathf.RoundToInt(baseHp * manager.hpMultiplier);
        float finalFireRate = baseFireRate * manager.fireRateMultiplier;

        // Kullanıcı girişini al
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Hareket vektörünü oluştur ve normalleştir
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        // Hareket vektörünü mevcut konum ile birleştirerek yeni pozisyonu belirle
        Vector3 newPosition = transform.position + movement * finalMoveSpeed * Time.deltaTime;

        // Yeni pozisyona git
        transform.position = newPosition;

        // Fare pozisyonunu al ve karakterin bakması gereken yönü belirle
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDirection = (mousePosition - transform.position).normalized;

        // Karakterin bakması gereken yöne dön
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // ScriptableObject referansı
    public EnemyData enemyData;

    // Hedef pozisyon
    private Transform target;
    public int hp;
    public float moveSpeed;

    void Start()
    {
        // Hedefi belirle
        target = GameObject.FindGameObjectWithTag("Player").transform;

        // EnemyData ScriptableObject'ten değerleri al
        int baseHp = enemyData.hp;
        float baseMoveSpeed = enemyData.moveSpeed;

        // Bu değerleri düşman nesnesine uygula
        hp = baseHp;
        moveSpeed = baseMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Hedefe doğru hareket et
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            // Hedefe doğru dön
            RotateTowardsTarget();
        }
    }

    // Hedefe doğru dönmeyi sağla
    void RotateTowardsTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, moveSpeed*10 * Time.deltaTime);
    }
}
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemy Data", order = 51)]
public class EnemyData : ScriptableObject
{
    public int damage = 1; // Hasar miktarı
    public int hp = 100; // Can
    public float moveSpeed = 5f; // Hareket hızı
    public float fireRate = 0.5f; // Ateş hızı
}

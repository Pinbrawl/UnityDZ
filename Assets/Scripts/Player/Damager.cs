using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealth enemyHealth))
            enemyHealth.TakeDamage(_damage, transform);
    }
}

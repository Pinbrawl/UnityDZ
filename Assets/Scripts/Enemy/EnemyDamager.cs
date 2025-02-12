using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerCondition playerCondition))
            playerCondition.TakeDamage(_damage, transform);
    }
}

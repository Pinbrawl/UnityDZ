using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health;

        if (collision.gameObject.TryGetComponent<Health>(out health))
            health.TakeDamage(_damage, null, true);
    }
}

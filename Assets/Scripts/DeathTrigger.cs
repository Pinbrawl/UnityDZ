using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
            health.TakeDamage(_damage, null, true);
    }
}

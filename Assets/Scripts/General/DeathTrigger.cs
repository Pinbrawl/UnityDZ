using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerCondition playerCondition))
            playerCondition.TakeDamage(_damage, null, true);
    }
}

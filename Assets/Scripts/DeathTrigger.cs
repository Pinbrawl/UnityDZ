using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player;

        if (collision.gameObject.TryGetComponent<Player>(out player))
            player.TakeDamage(_damage, null, true);
    }
}

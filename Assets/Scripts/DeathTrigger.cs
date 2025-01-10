using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
            player.TakeDamage(_damage, null, true);
    }
}

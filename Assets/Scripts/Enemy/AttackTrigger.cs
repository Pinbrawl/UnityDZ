using System;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public event Action<bool> IsTriggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out _))
            IsTriggered?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
            IsTriggered?.Invoke(false);
    }
}

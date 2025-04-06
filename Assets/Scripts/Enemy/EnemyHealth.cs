using System;
using UnityEngine;

public class EnemyHealth : Health
{
    public new event Action Dead;
    public event Action<Transform> DamageTaked;

    public void TakeDamage(int damage, Transform point)
    {
        _count = Mathf.Clamp(_count - damage, 0, _count);

        DamageTaked?.Invoke(point);

        if (_count == 0)
            Die();
    }

    protected override void Die()
    {
        Dead?.Invoke();
    }
}

using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _maxCount;
    [SerializeField] private int _count;

    public event Action Dead;
    public event Action<Transform> DamageTaked;

    public void TakeDamage(int damage, Transform point)
    {
        _count = Mathf.Clamp(_count - damage, 0, _count);

        DamageTaked?.Invoke(point);

        if (_count == 0)
            Death();
    }

    private void Death()
    {
        Dead?.Invoke();
    }
}

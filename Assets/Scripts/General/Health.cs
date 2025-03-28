using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxCount;
    [SerializeField] private int _count;
    [SerializeField] private int _healCount;

    public event Action<int> HealthChanged;
    public event Action Dead;

    private void Start()
    {
        HealthChanged?.Invoke(_count);
    }

    public void TakeDamage(int damage)
    {
        _count = Mathf.Clamp(_count - damage, 0, _maxCount);
        HealthChanged?.Invoke(_count);

        if (_count == 0)
            Death();
    }

    private void Death()
    {
        Dead?.Invoke();

        _count = _maxCount;

        HealthChanged?.Invoke(_count);
    }

    public void Heal()
    {
        _count = Mathf.Clamp(_count + _healCount, 0, _maxCount);
        HealthChanged?.Invoke(_count);
    }
}

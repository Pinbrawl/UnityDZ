using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxCount;
    [SerializeField] private int _count;
    [SerializeField] private int _healCount;

    public event Action<int> Changed;
    public event Action Dead;

    private void Start()
    {
        Changed?.Invoke(_count);
    }

    public void TakeDamage(int damage)
    {
        _count = Mathf.Clamp(_count - damage, 0, _maxCount);
        Changed?.Invoke(_count);

        if (_count == 0)
            Die();
    }

    public void AddHealth()
    {
        _count = Mathf.Clamp(_count + _healCount, 0, _maxCount);
        Changed?.Invoke(_count);
    }

    private void Die()
    {
        Dead?.Invoke();

        _count = _maxCount;

        Changed?.Invoke(_count);
    }
}

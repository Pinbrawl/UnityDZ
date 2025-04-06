using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int _maxCount;
    [SerializeField] protected int _count;
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

    protected virtual void Die()
    {
        Dead?.Invoke();

        _count = _maxCount;

        Changed?.Invoke(_count);
    }
}

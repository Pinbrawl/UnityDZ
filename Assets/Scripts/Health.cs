using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;

    public bool IsImmortality;

    public event Action<int> HealthChanged;
    public event Action<Transform> DamageTaked;
    public event Action Dead;

    private void Awake()
    {
        IsImmortality = false;
    }

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public void TakeDamage(int damage, Transform point = null, bool ignoreImmortality = false)
    {
        if (IsImmortality == false || ignoreImmortality == true)
        {
            _health = Math.Max(0, _health - damage);
            HealthChanged?.Invoke(_health);

            DamageTaked?.Invoke(point);

            if (_health == 0)
                Death();
        }
    }

    private void Death()
    {
        Dead?.Invoke();

        _health = _maxHealth;

        HealthChanged?.Invoke(_health);
    }
}

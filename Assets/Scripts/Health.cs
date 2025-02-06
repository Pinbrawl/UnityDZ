using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxCount;
    [SerializeField] private int _count;

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
        HealthChanged?.Invoke(_count);
    }

    public void TakeDamage(int damage, Transform point = null, bool ignoreImmortality = false)
    {
        if ((IsImmortality == false || ignoreImmortality == true) && damage > 0)
        {
            _count = Mathf.Clamp(_count - damage, 0, _count);
            HealthChanged?.Invoke(_count);

            DamageTaked?.Invoke(point);

            if (_count == 0)
                Death();
        }
    }

    private void Death()
    {
        Dead?.Invoke();

        _count = _maxCount;

        HealthChanged?.Invoke(_count);
    }
}

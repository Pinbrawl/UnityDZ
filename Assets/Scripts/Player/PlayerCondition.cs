using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Player))]
public class PlayerCondition : MonoBehaviour
{
    [SerializeField] private Immortalitier _immortalitier;

    private bool _isImmortality;

    private Health _health;
    private Player _player;

    private void Awake()
    {
        _isImmortality = false;

        _health = GetComponent<Health>();
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _immortalitier.ImmortalityChanged += ImmortalityChange;
    }

    private void OnDisable()
    {
        _immortalitier.ImmortalityChanged -= ImmortalityChange;
    }

    public void TakeDamage(int damage, Transform point = null, bool ignoreImmortality = false)
    {
        if ((_isImmortality == false || ignoreImmortality == true) && damage > 0)
        {
            _health.TakeDamage(damage);
            _player.OnDamageTaked(point);
        }
    }

    private void ImmortalityChange(bool isImmortality)
    {
        _isImmortality = isImmortality;
    }
}

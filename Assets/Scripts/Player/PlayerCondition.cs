using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Player))]
public class PlayerCondition : MonoBehaviour
{
    public bool IsImmortality;

    private Health _health;
    private Player _player;

    private void Awake()
    {
        IsImmortality = false;

        _health = GetComponent<Health>();
        _player = GetComponent<Player>();
    }

    public void TakeDamage(int damage, Transform point = null, bool ignoreImmortality = false)
    {
        if ((IsImmortality == false || ignoreImmortality == true) && damage > 0)
        {
            _health.TakeDamage(damage);
            _player.OnDamageTaked(point);
        }
    }
}

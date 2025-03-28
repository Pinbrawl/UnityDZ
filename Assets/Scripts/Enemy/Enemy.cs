using UnityEngine;

[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(EnemyHealth))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private AttackTrigger _attackTrigger;

    private Flipper _flipper;
    private EnemyMover _enemyMover;
    private EnemyHealth _enemyHealth;

    private void Awake()
    {
        _flipper = GetComponent<Flipper>();
        _enemyMover = GetComponent<EnemyMover>();
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnEnable()
    {
        _enemyHealth.Dead += Die;
        _enemyHealth.DamageTaked += DamageTaked;
        _attackTrigger.Triggered += GoToAttack;
    }

    private void OnDisable()
    {
        _enemyHealth.Dead -= Die;
        _enemyHealth.DamageTaked -= DamageTaked;
    }

    private void Update()
    {
        _flipper.Flip(_enemyMover.SpeedNow);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void DamageTaked(Transform point)
    {
        _enemyMover.Push(point);
    }

    private void GoToAttack(bool isTriggered)
    {
        if (isTriggered)
            _enemyMover.StartGoToAttack(_attackTrigger.transform);
        else
            _enemyMover.StopGoToAttack();
    }
}
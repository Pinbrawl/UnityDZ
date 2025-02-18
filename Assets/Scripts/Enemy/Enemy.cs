using UnityEngine;

[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(EnemyHealth))]
public class Enemy : MonoBehaviour
{
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
    }

    private void OnDisable()
    {
        _enemyHealth.Dead -= Die;
    }

    private void Update()
    {
        _flipper.Flip(_enemyMover.SpeedNow);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
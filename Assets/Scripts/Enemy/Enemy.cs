using UnityEngine;

[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    private Flipper _flipper;
    private EnemyMover _enemyMover;

    private void Awake()
    {
        _flipper = GetComponent<Flipper>();
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void Update()
    {
        _flipper.Flip(_enemyMover.SpeedNow);
    }
}
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyMover))]
public class EnemyAnimator : MonoBehaviour
{
    private readonly int _run = Animator.StringToHash("Run");

    private EnemyMover _enemyMover;
    private Animator _animator;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _enemyMover.Running += RunAnimationStart;
        _enemyMover.Stopping += RunAnimationStop;
    }

    private void OnDisable()
    {
        _enemyMover.Running -= RunAnimationStart;
        _enemyMover.Stopping -= RunAnimationStop;
    }

    private void RunAnimationStart()
    {
        _animator.SetBool(_run, true);
    }

    private void RunAnimationStop()
    {
        _animator.SetBool(_run, false);
    }
}

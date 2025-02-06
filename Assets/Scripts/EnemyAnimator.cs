using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private readonly int Run = Animator.StringToHash("Run");

    private Enemy _enemy;
    private Animator _animator;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _enemy.Running += RunAnimationStart;
        _enemy.Stopping += RunAnimationStop;
    }

    private void OnDisable()
    {
        _enemy.Running -= RunAnimationStart;
        _enemy.Stopping -= RunAnimationStop;
    }

    private void RunAnimationStart()
    {
        _animator.SetBool(Run, true);
    }

    private void RunAnimationStop()
    {
        _animator.SetBool(Run, false);
    }
}

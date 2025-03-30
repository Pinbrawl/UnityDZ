using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private readonly int _run = Animator.StringToHash("Run");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void RunAnimationStart()
    {
        _animator.SetBool(_run, true);
    }

    public void RunAnimationStop()
    {
        _animator.SetBool(_run, false);
    }
}

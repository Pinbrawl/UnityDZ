using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DamagerAnimator : MonoBehaviour
{
    private readonly int _isAttack = Animator.StringToHash("IsAttack");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Attack(bool isAttack)
    {
        _animator.SetBool(_isAttack, isAttack);
    }
}

using UnityEngine;

[RequireComponent(typeof(DamagerRotator))]
[RequireComponent(typeof(Animator))]
public class DamagerAnimator : MonoBehaviour
{
    private readonly int _isAttack = Animator.StringToHash("IsAttack");

    private DamagerRotator _damagerRotator;
    private Animator _animator;

    private void Awake()
    {
        _damagerRotator = GetComponent<DamagerRotator>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _damagerRotator.Attacked += Attack;
    }

    private void OnDisable()
    {
        _damagerRotator.Attacked -= Attack;
    }

    private void Attack(bool isAttack)
    {
        _animator.SetBool(_isAttack, isAttack);
    }
}

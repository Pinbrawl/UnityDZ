using UnityEngine;

[RequireComponent(typeof(Damager))]
[RequireComponent(typeof(Animator))]
public class DamagerAnimator : MonoBehaviour
{
    private readonly int _isAttack = Animator.StringToHash("IsAttack");

    private Damager _damager;
    private Animator _animator;

    private void Awake()
    {
        _damager = GetComponent<Damager>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _damager.IsAttack += Attack;
    }

    private void OnDisable()
    {
        _damager.IsAttack -= Attack;
    }

    private void Attack(bool isAttack)
    {
        _animator.SetBool(_isAttack, isAttack);
    }
}

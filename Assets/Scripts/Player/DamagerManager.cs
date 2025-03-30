using System.Collections;
using UnityEngine;

[RequireComponent(typeof(DamagerAnimator))]
public class DamagerManager : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _attackTime;
    [SerializeField] private Damager _damager;

    private Coroutine _coroutine;
    private WaitForSeconds _waitTime;
    private DamagerAnimator _damagerAnimator;

    private void Awake()
    {
        _damager.gameObject.SetActive(false);

        _waitTime = new WaitForSeconds(_attackTime);
        _damagerAnimator = GetComponent<DamagerAnimator>();
    }

    private void FixedUpdate()
    {
        if (_inputReader.IsAttack())
            StartAttack();
    }

    private void StartAttack()
    {
        if (_coroutine == null)
            _coroutine = StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        _damagerAnimator.Attack(true);
        _damager.gameObject.SetActive(true);

        yield return _waitTime;

        _damagerAnimator.Attack(false);
        _damager.gameObject.SetActive(false);

        _coroutine = null;
    }
}

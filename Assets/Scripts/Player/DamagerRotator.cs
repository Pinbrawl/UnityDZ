using System;
using System.Collections;
using UnityEngine;

public class DamagerRotator : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _attackTime;
    [SerializeField] private Damager _damager;

    private Coroutine _coroutine;
    private WaitForSeconds _waitTime;

    public event Action<bool> IsAttack;

    private void Awake()
    {
        _damager.gameObject.SetActive(false);

        _waitTime = new WaitForSeconds(_attackTime);
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
        IsAttack?.Invoke(true);
        _damager.gameObject.SetActive(true);

        yield return _waitTime;

        IsAttack?.Invoke(false);
        _damager.gameObject.SetActive(false);

        _coroutine = null;
    }
}

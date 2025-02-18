using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(DamagerRotator))]
public class Damager : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackTime;

    private DamagerRotator _damagerRotator;
    private Coroutine _coroutine;
    private Damager _damager;

    public event Action<bool> IsAttack;

    private void Awake()
    {
        _damagerRotator = GetComponent<DamagerRotator>();
        _damager = GetComponent<Damager>();

        _damager.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealth enemyHealth))
            enemyHealth.TakeDamage(_damage);
    }

    private void OnEnable()
    {
        _damagerRotator.Attacking += StartAttack;
    }

    private void OnDisable()
    {
        _damagerRotator.Attacking -= StartAttack;
    }

    private void StartAttack()
    {
        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        IsAttack?.Invoke(true);
        _damager.gameObject.SetActive(true);

        yield return new WaitForSeconds(_attackTime);

        IsAttack?.Invoke(false);
        _damager.gameObject.SetActive(false);
    }
}

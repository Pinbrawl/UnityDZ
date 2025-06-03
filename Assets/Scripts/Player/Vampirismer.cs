using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampirismer : MonoBehaviour
{
    [SerializeField] private InputReader _input;
    [SerializeField] private Health _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _seconds;
    [SerializeField] private float _interval;
    [SerializeField] private float _rechargeTime;

    private Coroutine _coroutineVampirism;
    private Coroutine _coroutineRecharge;
    private int _damageCount;
    private bool _canDoVampirism;
    private List<GameObject> _enemies = new List<GameObject>();

    public event Action Vanpirisming;
    public event Action VanpirismEnding;
    public event Action<int, int> Changed;

    private void Awake()
    {
        _damageCount = (int)(_seconds / _interval);
        _canDoVampirism = true;

        Changed?.Invoke(0, _damageCount);
    }

    private void Update()
    {
        if(_input.IsVampirism() && _canDoVampirism)
            StartVampirism();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out _))
            _enemies.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out _))
            _enemies.Remove(collision.gameObject);
    }

    private void StartVampirism()
    {
        if( _coroutineVampirism != null)
            StopCoroutine(_coroutineVampirism);

        _coroutineVampirism = StartCoroutine(DoVampirism());
    }

    private IEnumerator DoVampirism()
    {
        Vanpirisming?.Invoke();
        _canDoVampirism = false;

        var interval = new WaitForSecondsRealtime(_interval);

        for (int j = 0; j < _damageCount; j++)
        {
            Health targetHealth = null;

            if(_enemies.Count > 0)
            {
                targetHealth = _enemies[0].GetComponent<Health>();

                for(int i = 1; i < _enemies.Count; i++)
                {
                    Vector3 distance = new Vector3(Mathf.Abs(_enemies[i].transform.position.x - transform.position.x), Mathf.Abs(_enemies[i].transform.position.y - transform.position.y), 0);

                    if (distance == Vector3.Min(new Vector3(Mathf.Abs(targetHealth.transform.position.x - transform.position.x), Mathf.Abs(targetHealth.transform.position.y - transform.position.y), 0), distance))
                        targetHealth = _enemies[i].GetComponent<Health>();
                }

                _health.AddHealth(_damage);
                targetHealth.TakeDamage(_damage);
            }

            Changed?.Invoke(_damageCount - j, _damageCount);
            
            yield return interval;
        }

        Changed?.Invoke(0, _damageCount);
        VanpirismEnding?.Invoke();

        StartWaitRecharge();
    }

    private void StartWaitRecharge()
    {
        if(_coroutineRecharge != null)
            StopCoroutine( _coroutineRecharge);

        _coroutineRecharge = StartCoroutine(WaitRecharge());
    }

    private IEnumerator WaitRecharge()
    {
        yield return new WaitForSecondsRealtime(_rechargeTime);

        _canDoVampirism = true;
    }
}

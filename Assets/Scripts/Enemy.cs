using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Flipper))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _secondsForRelax;
    [SerializeField] private List<Transform> _wayPoints;

    private float _speedNow;

    private Flipper _flipper;

    public event Action Running;
    public event Action Stopping;

    private void Awake()
    {
        _speedNow = 0;

        _flipper = GetComponent<Flipper>();
    }

    private void Start()
    {
        StartCoroutine(GetNextWay());
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
            health.TakeDamage(_damage, transform);
    }

    private IEnumerator GetNextWay()
    {
        var relaxTime = new WaitForSeconds(_secondsForRelax);
        int pointIndex = 0;

        while(enabled)
        {
            pointIndex = ++pointIndex % _wayPoints.Count;

            Transform point = _wayPoints[pointIndex];
            yield return GoToPoint(point);

            yield return relaxTime;
        }
    }

    private IEnumerator GoToPoint(Transform point)
    {
        Running?.Invoke();

        bool isEnd = false;

        while(isEnd == false)
        {
            float xPosition = Mathf.MoveTowards(transform.position.x, point.position.x, _speed * Time.deltaTime);
            _speedNow = xPosition - transform.position.x;
            transform.position = new Vector2(xPosition, transform.position.y);

            _flipper.Flip(_speedNow);

            isEnd = transform.position.x == point.position.x;

            yield return null;
        }

        _speedNow = 0;

        Stopping?.Invoke();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _secondsForRelax;
    [SerializeField] private float _dropStrength;
    [SerializeField] private List<Transform> _wayPoints;

    public float SpeedNow;

    private Rigidbody2D _rigidbody2D;

    public event Action Running;
    public event Action Stopping;

    private void Awake()
    {
        SpeedNow = 0;

        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(Move());
    }

    public void Push(Transform point)
    {
        _rigidbody2D.velocity = (transform.position - point.position).normalized * _dropStrength;
    }

    public void StartGoToAttack(Transform point)
    {
        StopAllCoroutines();
        StartCoroutine(GoToAttack(point));
    }

    public void StopGoToAttack()
    {
        StopAllCoroutines();
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        var relaxTime = new WaitForSeconds(_secondsForRelax);
        int pointIndex = 0;

        while (enabled)
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

        while (isEnd == false)
        {
            float xPosition = Mathf.MoveTowards(transform.position.x, point.position.x, _speed * Time.deltaTime);
            SpeedNow = xPosition - transform.position.x;
            transform.position = new Vector2(xPosition, transform.position.y);

            isEnd = transform.position.x == point.position.x;

            yield return null;
        }

        SpeedNow = 0;

        Stopping?.Invoke();
    }

    private IEnumerator GoToAttack(Transform point)
    {
        Running?.Invoke();

        while (enabled)
        {
            float xPosition = Mathf.MoveTowards(transform.position.x, point.position.x, _speed * Time.deltaTime);
            SpeedNow = xPosition - transform.position.x;
            transform.position = new Vector2(xPosition, transform.position.y);

            yield return null;
        }

        SpeedNow = 0;

        Stopping?.Invoke();
    }
}

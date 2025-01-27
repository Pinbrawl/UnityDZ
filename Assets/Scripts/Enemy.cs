using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _secondsForRelax;
    [SerializeField] private List<Transform> _wayPoints;

    private const string _runParameterName = "Run";

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(SetWay());
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
            player.TakeDamage(_damage, transform);
    }

    private IEnumerator SetWay()
    {
        var relaxTime = new WaitForSeconds(_secondsForRelax);

        for(int pointIndex = 0; enabled; pointIndex++)
        {
            if(pointIndex == _wayPoints.Count)
                pointIndex = 0;

            Transform point = _wayPoints[pointIndex];
            StartCoroutine(GoToPoint(point));

            while(transform.position.x != point.position.x)
            {
                yield return null;
            }

            yield return relaxTime;
        }
    }

    private IEnumerator GoToPoint(Transform point)
    {
        _animator.SetBool(_runParameterName, true);

        Flip(point);

        bool isEnd = false;

        while(isEnd == false)
        {
            float xPosition = Mathf.MoveTowards(transform.position.x, point.position.x, _speed * Time.deltaTime);
            transform.position = new Vector2(xPosition, transform.position.y);

            isEnd = transform.position.x == point.position.x;

            yield return null;
        }

        _animator.SetBool(_runParameterName, false);
    }

    private void Flip(Transform point)
    {
        if (point.position.x > transform.position.x)
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        else if (point.position.x < transform.position.x)
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
    }
}
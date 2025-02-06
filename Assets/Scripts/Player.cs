using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Flipper))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GroundChecker _onGroundChecker;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _dropStrength;
    [SerializeField] private float _secondsImmortality;
    [SerializeField] private float _secondsForBlinking;

    private float _speedNow;
    private bool _onGround;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Coroutine _coroutine;
    private InputReader _inputReader;
    private Health _health;
    private Flipper _flipper;

    public event Action Running;
    public event Action Stopping;
    public event Action<bool> OnGroundChanged;
    public event Action<float> SpeedYChanged;

    private void Awake()
    {
        transform.position = _spawnPoint.position;

        _onGround = false;

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _inputReader = GetComponent<InputReader>();
        _health = GetComponent<Health>();
        _flipper = GetComponent<Flipper>();
    }

    private void OnEnable()
    {
        _onGroundChecker.OnGroundChanged += OnGroundChange;
        _health.DamageTaked += TakeDamage;
        _health.Dead += Death;
    }

    private void OnDisable()
    {
        _onGroundChecker.OnGroundChanged -= OnGroundChange;
        _health.DamageTaked -= TakeDamage;
        _health.Dead -= Death;
    }

    private void FixedUpdate()
    {
        Run();

        if (_inputReader.IsJump() && _onGround)
            Jump();
    }

    private void Update()
    {
        ChangeAnimatorParameters();
    }

    public void TakeDamage(Transform point)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(DoImmortality());

        if (point != null)
            Drop(point);
    }

    private IEnumerator DoImmortality()
    {
        var blinkingTime = new WaitForSeconds(_secondsForBlinking);
        float timeImmortality = _secondsImmortality;
        _health.IsImmortality = true;

        while (timeImmortality > 0)
        {
            _spriteRenderer.enabled = !_spriteRenderer.enabled;

            if (timeImmortality <= _secondsForBlinking)
            {
                yield return new WaitForSeconds(timeImmortality);

                timeImmortality = 0;
            }
            else
            {
                yield return blinkingTime;

                timeImmortality -= _secondsForBlinking;
            }
        }

        _health.IsImmortality = false;
        _spriteRenderer.enabled = true;
    }

    private void Drop(Transform point)
    {
        _rigidbody2D.velocity = (transform.position - point.position).normalized * _dropStrength;
    }

    private void ChangeAnimatorParameters()
    {
        if (_speedNow != 0)
            Running?.Invoke();
        else
            Stopping?.Invoke();

        SpeedYChanged?.Invoke(_rigidbody2D.velocity.y);
    }

    private void OnGroundChange(bool onGround)
    {
        _onGround = onGround;
        OnGroundChanged?.Invoke(_onGround);
    }

    private void Run()
    {
        _speedNow = _speed * _inputReader.Direction;
        transform.Translate(transform.right * (_speedNow * Time.deltaTime));
        _flipper.Flip(_speedNow);
    }

    private void Jump()
    {
        _rigidbody2D.velocity = Vector2.up * _jumpForce;
    }

    private void Death()
    {
        _rigidbody2D.velocity = Vector2.zero;
        transform.position = _spawnPoint.position;
    }
}
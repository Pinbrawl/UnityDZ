using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;
    [SerializeField] private float _flipBorder;
    [SerializeField] private float _dropStrength;
    [SerializeField] private float _secondsImmortality;
    [SerializeField] private float _secondsForBlinking;

    private float _raycastLength;
    private float _speedNow;
    private string _horizontal = "Horizontal";
    private string _platformLayer;
    private const string _onGroundParameterName = "OnGround";
    private const string _speedXParameterName = "SpeedX";
    private const string _speedYParameterName = "SpeedY";
    private bool _onGround;
    private bool _isImmortality;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private KeyCode _jumpKey;
    private Coroutine _coroutine;

    public event Action<int> HealthChanged;

    private void Awake()
    {
        transform.position = _spawnPoint.position;

        _raycastLength = 1.1f;
        _platformLayer = "Platform";
        _isImmortality = false;

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _jumpKey = KeyCode.Space;

        HealthChanged?.Invoke(_health);
    }

    private void Update()
    {
        Run();
        _onGround = OnGround();

        if (Input.GetKeyDown(_jumpKey) && _onGround)
            Jump();

        ChangeAnimatorsParameters();
        Flip();
    }

    public void TakeDamage(int damage, Transform point = null, bool ignoreImmortality = false)
    {
        if(_isImmortality == false || ignoreImmortality == true)
        {
            _health = Math.Max(0, _health - damage);
            HealthChanged?.Invoke(_health);

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(DoImmortality());

            if(point != null)
                Drop(point);

            if (_health == 0)
                Death();
        }
    }

    private IEnumerator DoImmortality()
    {
        var blinkingTime = new WaitForSeconds(_secondsForBlinking);
        float timeImmortality = _secondsImmortality;
        _isImmortality = true;

        while(timeImmortality > 0)
        {
            _spriteRenderer.enabled = !_spriteRenderer.enabled;

            if(timeImmortality <= _secondsForBlinking)
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

        _isImmortality = false;
        _spriteRenderer.enabled = true;
    }

    private void Drop(Transform point)
    {
        _rigidbody2D.velocity = (transform.position - point.position).normalized * _dropStrength;
    }

    private void ChangeAnimatorsParameters()
    {
        _animator.SetBool(_onGroundParameterName, _onGround);
        _animator.SetFloat(_speedXParameterName, Math.Abs(_speedNow));
        _animator.SetFloat(_speedYParameterName, _rigidbody2D.velocity.y);
    }

    private bool OnGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _raycastLength, LayerMask.GetMask(_platformLayer));

        return hit;
    }

    private void Run()
    {
        _speedNow = _speed * Input.GetAxis(_horizontal);
        transform.Translate(transform.right * (_speedNow * Time.deltaTime));
    }

    private void Jump()
    {
        _rigidbody2D.velocity = Vector2.up * _jumpForce;
    }

    private void Flip()
    {
        if (_speedNow > _flipBorder)
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        else if (_speedNow < _flipBorder)
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
    }

    private void Death()
    {
        _rigidbody2D.velocity = Vector2.zero;
        transform.position = _spawnPoint.position;
        _health = _maxHealth;

        HealthChanged?.Invoke(_health);
    }

    //private KeyCode InputReader()
    //{
    //    //return ;
    //}
}
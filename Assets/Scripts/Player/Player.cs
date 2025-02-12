using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Immortalitier))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GroundChecker _onGroundChecker;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private float _dropStrength;

    private bool _isGrounded;

    private Rigidbody2D _rigidbody2D;
    private Coroutine _coroutine;
    private InputReader _inputReader;
    private Health _health;
    private Flipper _flipper;
    private Mover _mover;
    private Immortalitier _immortalitier;
    private ItemPickUper _itemPickUper;

    public event Action Running;
    public event Action Stopping;
    public event Action<bool> OnGroundChanged;
    public event Action<float> SpeedYChanged;

    private void Awake()
    {
        transform.position = _spawnPoint.position;

        _isGrounded = false;

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _inputReader = GetComponent<InputReader>();
        _health = GetComponent<Health>();
        _flipper = GetComponent<Flipper>();
        _mover = GetComponent<Mover>();
        _immortalitier = GetComponent<Immortalitier>();
        _itemPickUper = GetComponent<ItemPickUper>();
    }

    private void OnEnable()
    {
        _onGroundChecker.OnGroundChanged += OnGroundChange;
        _health.Dead += Death;
        _itemPickUper.PickUpCoin += CoinPickUped;
    }

    private void OnDisable()
    {
        _onGroundChecker.OnGroundChanged -= OnGroundChange;
        _health.Dead -= Death;
        _itemPickUper.PickUpCoin -= CoinPickUped;
    }

    private void FixedUpdate()
    {
        Run();

        if (_inputReader.IsJump() && _isGrounded)
            _mover.Jump();
    }

    private void Update()
    {
        ChangeAnimatorParameters();
    }

    private void CoinPickUped()
    {
        _wallet.AddCoin();
    }

    public void OnDamageTaked(Transform point)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(_immortalitier.DoImmortality());

        if (point != null)
            Push(point);
    }

    private void Push(Transform point)
    {
        _rigidbody2D.velocity = (transform.position - point.position).normalized * _dropStrength;
    }

    private void ChangeAnimatorParameters()
    {
        if (_mover.SpeedNow != 0)
            Running?.Invoke();
        else
            Stopping?.Invoke();

        SpeedYChanged?.Invoke(_rigidbody2D.velocity.y);
    }

    private void OnGroundChange(bool isGrounded)
    {
        _isGrounded = isGrounded;
        OnGroundChanged?.Invoke(_isGrounded);
    }

    private void Run()
    {
        _mover.Run(_inputReader.Direction);
        _flipper.Flip(_mover.SpeedNow);
    }

    private void Death()
    {
        _rigidbody2D.velocity = Vector2.zero;
        transform.position = _spawnPoint.position;
    }
}
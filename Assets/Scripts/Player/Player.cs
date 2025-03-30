using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Immortalitier))]
[RequireComponent(typeof(PlayerAnimator))]
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
    private PlayerAnimator _playerAnimator;

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
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void OnEnable()
    {
        _onGroundChecker.GroundChanged += OnGroundChange;
        _health.Dead += Die;
        _itemPickUper.PickUpCoin += CoinPickUped;
        _itemPickUper.PickUpHealBox += HealBoxPickUped;
    }

    private void OnDisable()
    {
        _onGroundChecker.GroundChanged -= OnGroundChange;
        _health.Dead -= Die;
        _itemPickUper.PickUpCoin -= CoinPickUped;
        _itemPickUper.PickUpHealBox -= HealBoxPickUped;
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

    public void OnDamageTaked(Transform point)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(_immortalitier.DoImmortality());

        if (point != null)
            Push(point);
    }

    private void CoinPickUped()
    {
        _wallet.AddCoin();
    }

    private void HealBoxPickUped()
    {
        _health.AddHealth();
    }

    private void Push(Transform point)
    {
        _rigidbody2D.velocity = (transform.position - point.position).normalized * _dropStrength;
    }

    private void ChangeAnimatorParameters()
    {
        if (_mover.SpeedNow != 0)
            _playerAnimator.Run();
        else
            _playerAnimator.Stop();

        _playerAnimator.SpeedYChange(_rigidbody2D.velocity.y);
    }

    private void OnGroundChange(bool isGrounded)
    {
        _isGrounded = isGrounded;
        _playerAnimator.OnGroundChange(_isGrounded);
    }

    private void Run()
    {
        _mover.Run(_inputReader.Direction);
        _flipper.Flip(_mover.SpeedNow);
    }

    private void Die()
    {
        _rigidbody2D.velocity = Vector2.zero;
        transform.position = _spawnPoint.position;
    }
}
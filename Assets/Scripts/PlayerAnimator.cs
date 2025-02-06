using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class PlayerAnimator : MonoBehaviour
{
    private readonly int _onGround = Animator.StringToHash("OnGround");
    private readonly int _isRun = Animator.StringToHash("IsRun");
    private readonly int _speedY = Animator.StringToHash("SpeedY");

    private Player _player;
    private Animator _animator;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _player.Running += Run;
        _player.Stopping += Stop;
        _player.SpeedYChanged += SpeedYChange;
        _player.OnGroundChanged += OnGroundChange;
    }

    private void OnDisable()
    {
        _player.Running -= Run;
        _player.Stopping -= Stop;
        _player.SpeedYChanged -= SpeedYChange;
        _player.OnGroundChanged -= OnGroundChange;
    }

    private void Run()
    {
        _animator.SetBool(_isRun, true);
    }

    private void Stop()
    {
        _animator.SetBool(_isRun, false);
    }

    private void SpeedYChange(float speedY)
    {
        _animator.SetFloat(_speedY, speedY);
    }

    private void OnGroundChange(bool onGround)
    {
        _animator.SetBool(_onGround, onGround);
    }
}

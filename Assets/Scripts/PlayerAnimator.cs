using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class PlayerAnimator : MonoBehaviour
{
    private readonly int OnGround = Animator.StringToHash("OnGround");
    private readonly int IsRun = Animator.StringToHash("IsRun");
    private readonly int SpeedY = Animator.StringToHash("SpeedY");

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
        _animator.SetBool(IsRun, true);
    }

    private void Stop()
    {
        _animator.SetBool(IsRun, false);
    }

    private void SpeedYChange(float speedY)
    {
        _animator.SetFloat(SpeedY, speedY);
    }

    private void OnGroundChange(bool onGround)
    {
        _animator.SetBool(OnGround, onGround);
    }
}

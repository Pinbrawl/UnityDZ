using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private readonly int _onGround = Animator.StringToHash("OnGround");
    private readonly int _isRun = Animator.StringToHash("IsRun");
    private readonly int _speedY = Animator.StringToHash("SpeedY");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Run()
    {
        _animator.SetBool(_isRun, true);
    }

    public void Stop()
    {
        _animator.SetBool(_isRun, false);
    }

    public void SpeedYChange(float speedY)
    {
        _animator.SetFloat(_speedY, speedY);
    }

    public void OnGroundChange(bool onGround)
    {
        _animator.SetBool(_onGround, onGround);
    }
}

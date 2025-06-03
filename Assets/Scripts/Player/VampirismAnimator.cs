using UnityEngine;

[RequireComponent(typeof(Animator))]
public class VampirismAnimator : MonoBehaviour
{
    [SerializeField] private Vampirismer _vampirismer;

    private Animator _animator;
    private string _isVampirismName = "IsVampirism";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _vampirismer.Vanpirisming += StartVampirism;
        _vampirismer.VanpirismEnding += StopVampirism;
    }

    private void OnDisable()
    {
        _vampirismer.Vanpirisming -= StartVampirism;
        _vampirismer.VanpirismEnding -= StopVampirism;
    }

    private void StartVampirism()
    {
        _animator.SetBool(_isVampirismName, true);
    }

    private void StopVampirism()
    {
        _animator.SetBool(_isVampirismName, false);
    }
}

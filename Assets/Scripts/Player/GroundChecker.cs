using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private bool _isGrounded;

    public event Action<bool> OnGroundChanged;

    private void Awake()
    {
        _isGrounded = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _isGrounded = true;
    }

    private void Update()
    {
        OnGroundChanged?.Invoke(_isGrounded);
        _isGrounded = false;
    }
}

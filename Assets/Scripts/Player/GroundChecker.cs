using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private LayerMask _groundLayer;

    public event Action<bool> OnGroundChanged;

    private void Awake()
    {
        _groundLayer = LayerMask.NameToLayer("Platform");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _groundLayer)
            OnGroundChanged?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        OnGroundChanged?.Invoke(false);
    }
}

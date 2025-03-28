using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private int _groundCount;

    private LayerMask _groundLayer;

    public event Action<bool> GroundChanged;

    private void Awake()
    {
        _groundLayer = LayerMask.NameToLayer("Platform");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _groundLayer)
        {
            GroundChanged?.Invoke(true);
            _groundCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.layer == _groundLayer)
        {
            _groundCount--;

            if (_groundCount < 1)
                GroundChanged?.Invoke(false);
        }
    }
}

using System;
using UnityEngine;

public class OnGroundChecker : MonoBehaviour
{
    private string _platformLayer;

    public event Action<bool> OnGroundChanged;

    private void Awake()
    {
        _platformLayer = "Platform";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer(_platformLayer))
            OnGroundChanged?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(_platformLayer))
            OnGroundChanged?.Invoke(false);
    }
}

using System;
using UnityEngine;

public class OnGroundChecker : MonoBehaviour
{
    private string _platformLayer;
    private int layer;

    public event Action<bool> OnGroundChanged;

    private void Awake()
    {
        _platformLayer = "Platform";
        layer = LayerMask.NameToLayer(_platformLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == layer)
            OnGroundChanged?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layer)
            OnGroundChanged?.Invoke(false);
    }
}

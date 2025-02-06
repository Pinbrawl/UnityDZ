using System;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public event Action<bool> OnGroundChanged;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnGroundChanged?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnGroundChanged?.Invoke(false);
    }
}

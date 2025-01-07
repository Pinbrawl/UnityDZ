using System;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public event Action TriggerPassed;

    private void OnTriggerExit(Collider other)
    {
        TriggerPassed?.Invoke();
    }
}
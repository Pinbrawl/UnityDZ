using System;
using UnityEngine;

public class Detectorator : MonoBehaviour
{
    public event Action Detection;

    private void OnTriggerExit(Collider other)
    {
        Detection?.Invoke();
    }
}
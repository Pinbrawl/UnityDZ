using System;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public event Action ObjectEnter;
    public event Action ObjectExit;

    private void OnTriggerEnter(Collider other)
    {
        ObjectEnter?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        ObjectExit?.Invoke();
    }
}
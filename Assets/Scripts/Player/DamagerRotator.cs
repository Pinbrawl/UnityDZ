using System;
using UnityEngine;

public class DamagerRotator : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    public event Action Attacking;

    private void FixedUpdate()
    {
        if (_inputReader.IsAttack())
            Attacking?.Invoke();
    }
}

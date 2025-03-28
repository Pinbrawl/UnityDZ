using UnityEngine;

public class HealthView : View
{
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.Changed += Print;
    }

    private void OnDisable()
    {
        _health.Changed -= Print;
    }
}

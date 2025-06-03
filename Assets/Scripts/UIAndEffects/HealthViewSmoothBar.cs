using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthViewSmoothBar : MonoBehaviour
{
    [SerializeField] private Slider _bar;
    [SerializeField] private Health _health;
    [SerializeField] private float _changeSpeed;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _health.Changed += Print;
    }

    private void OnDisable()
    {
        _health.Changed -= Print;
    }

    protected void Print(int health, int maxHealth)
    {
        StartChangeValue((float)health / maxHealth);
    }

    public void StartChangeValue(float value)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeValue(value));
    }

    private IEnumerator ChangeValue(float value)
    {
        while (Mathf.Approximately(_bar.value, value) == false)
        {
            _bar.value = Mathf.MoveTowards(_bar.value, value, _changeSpeed);
            yield return null;
        }
    }
}

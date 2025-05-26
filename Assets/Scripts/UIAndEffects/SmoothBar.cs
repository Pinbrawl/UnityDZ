using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothBar : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Coroutine _coroutine;
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void StartChangeValue(int value, int maxValue)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeValue((float)value / maxValue));
    }

    private IEnumerator ChangeValue(float value)
    {
        while(_slider.value != value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, value, _speed);
            yield return null;
        }
    }
}

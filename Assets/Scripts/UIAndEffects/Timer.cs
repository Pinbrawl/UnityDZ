using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    [SerializeField] private Vampirismer _vampirismer;
    [SerializeField] private Slider _bar;
    [SerializeField] private GameObject _allBar;
    [SerializeField] private float _changeSpeed;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _vampirismer.Changed += Print;
    }

    private void OnDisable()
    {
        _vampirismer.Changed -= Print;
    }

    private void Print(int count, int _maxCount)
    {
        StartChangeValue((float)count / _maxCount);

        if (count == 0)
            _allBar.SetActive(false);
        else
            _allBar.SetActive(true);
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

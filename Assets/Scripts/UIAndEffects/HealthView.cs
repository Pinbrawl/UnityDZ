using UnityEngine;
using UnityEngine.UI;

public class HealthView : View
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _bar;
    [SerializeField] private SmoothBar _smoothBar;

    private void OnEnable()
    {
        _health.Changed += PrintWithMaxCount;
    }

    private void OnDisable()
    {
        _health.Changed -= PrintWithMaxCount;
    }

    private void PrintWithMaxCount(int count, int maxCount)
    {
        Print(count);
        _textForCount.text += "/" + maxCount;

        _bar.value = (float)count / maxCount;

        _smoothBar.StartChangeValue(count, maxCount);
    }
}

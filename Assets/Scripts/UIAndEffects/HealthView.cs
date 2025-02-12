using TMPro;
using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private string _baseStringForPrint;
    [SerializeField] private TextMeshProUGUI _textForCount;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.HealthChanged += Print;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= Print;
    }

    private void Print(int health)
    {
        _textForCount.text = _baseStringForPrint + ": " + health;
    }
}

using TMPro;
using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private string _baseStringForHealthPrint;
    [SerializeField] private TextMeshProUGUI _textForHealthCount;
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
        _textForHealthCount.text = _baseStringForHealthPrint + " " + health;
    }
}

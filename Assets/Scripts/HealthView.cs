using TMPro;
using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private string _baseStringForHealthPrint;
    [SerializeField] private TextMeshProUGUI _textForHealthCount;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChanged += PrintHealth;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= PrintHealth;
    }

    private void PrintHealth(int health)
    {
        _textForHealthCount.text = _baseStringForHealthPrint + " " + health;
    }
}

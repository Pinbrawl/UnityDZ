using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private string _baseString;
    [SerializeField] private TextMeshProUGUI _text;
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
        _text.text = _baseString + " " + health;
    }
}

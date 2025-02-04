using TMPro;
using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private string _baseStringForHealthPrint;
    [SerializeField] private TextMeshProUGUI _textForHealthCount;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChanged += Print;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= Print;
    }

    private void Print(int health)
    {
        _textForHealthCount.text = _baseStringForHealthPrint + " " + health;
    }
}

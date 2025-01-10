using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private string _baseString;
    [SerializeField] private TextMeshProUGUI _text;

    private int _coins;

    private void Awake()
    {
        _coins = 0;

        PrintCoins();
    }

    public void AddCoin()
    {
        _coins++;
        PrintCoins();
    }

    private void PrintCoins()
    {
        _text.text = _baseString + " " + _coins;
    }
}
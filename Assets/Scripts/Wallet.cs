using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private string _baseString;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private ItemPickUper _itemPickUper;

    private int _coins;

    private void Awake()
    {
        _coins = 0;

        PrintCoins();
    }

    private void OnEnable()
    {
        _itemPickUper.PickUpCoin += AddCoin;
    }

    private void OnDisable()
    {
        _itemPickUper.PickUpCoin -= AddCoin;
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
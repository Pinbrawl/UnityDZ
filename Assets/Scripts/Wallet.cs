using System;
using UnityEngine;

[RequireComponent(typeof(ItemPickUper))]
public class Wallet : MonoBehaviour
{
    private ItemPickUper _itemPickUper;

    private int _coins;

    public event Action<int> CoinChanged;

    private void Awake()
    {
        _coins = 0;

        _itemPickUper = GetComponent<ItemPickUper>();
    }

    private void Start()
    {
        CoinChanged?.Invoke(_coins);
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

        CoinChanged?.Invoke(_coins);
    }
}
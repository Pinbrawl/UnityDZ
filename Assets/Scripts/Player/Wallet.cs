using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _coins;

    public event Action<int> CoinChanged;

    private void Awake()
    {
        _coins = 0;
    }

    private void Start()
    {
        CoinChanged?.Invoke(_coins);
    }

    public void AddCoin()
    {
        _coins++;

        CoinChanged?.Invoke(_coins);
    }
}
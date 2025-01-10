using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private Wallet _wallet;

    private void Awake()
    {
        SpawnCoin();
    }

    private void SpawnCoin()
    {
        Transform randomPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
        Coin coin = Instantiate(_coin, randomPoint);
        coin.PickUped += CoinPickUped;
    }

    private void CoinPickUped(Coin coin)
    {
        _wallet.AddCoin();
        SpawnCoin();
    }
}
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private List<Transform> _spawnPoints;

    private void Awake()
    {
        Spawn();
    }

    private void Spawn()
    {
        Transform randomPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
        Coin coin = Instantiate(_coin, randomPoint);
        coin.Removed += CoinPickUped;
    }

    private void CoinPickUped(Coin coin)
    {
        coin.Removed -= CoinPickUped;
        Spawn();
    }
}
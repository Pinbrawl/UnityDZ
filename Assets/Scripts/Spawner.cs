using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _step;
    [SerializeField] private bool _isActive;
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    private void Awake()
    {
        StartCoroutine(DelayedSpawnRepeating());
    }

    private IEnumerator DelayedSpawnRepeating()
    {
        var time = new WaitForSeconds(_step);

        while (_isActive)
        {
            yield return time;
            Spawn();
        }
    }

    private void Spawn()
    {
        int randomSpawnPointIndex = Random.Range(0, _spawnPoints.Count);
        _spawnPoints[randomSpawnPointIndex].Spawn();
    }
}
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _step;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private List<GameObject> _spawnPoints;
    [SerializeField] private bool _isActive;

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
        float minCoordinate = -10;
        float maxCoordinate = 10;

        Vector3 direction = new Vector3(Random.Range(minCoordinate, maxCoordinate), 0, Random.Range(minCoordinate, maxCoordinate)).normalized;

        int randomSpawnPointIndex = Random.Range(0, _spawnPoints.Count);

        Enemy enemy = Instantiate(_enemy, _spawnPoints[randomSpawnPointIndex].transform.position, Quaternion.identity);
        enemy.Direction = direction;
    }
}

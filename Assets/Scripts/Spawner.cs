using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        while(_isActive)
        {
            yield return new WaitForSecondsRealtime(_step);
            Spawn();
        }
    }

    private void Spawn()
    {
        int minRotate = 0;
        int maxRotate = 360;

        int randomSpawnPointIndex = Random.Range(0, _spawnPoints.Count);
        Quaternion rotate = Quaternion.Euler(0, Random.Range(minRotate, maxRotate), 0);

        Instantiate(_enemy, _spawnPoints[randomSpawnPointIndex].transform.position, rotate);
    }
}

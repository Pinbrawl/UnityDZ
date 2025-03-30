using System.Collections.Generic;
using UnityEngine;

public class HealBoxSpawner : MonoBehaviour
{
    [SerializeField] private HealBox _healBox;
    [SerializeField] private List<Transform> _spawnPoints;

    private void Awake()
    {
        Spawn();
    }

    private void Spawn()
    {
        Transform randomPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
        HealBox healBox = Instantiate(_healBox, randomPoint);
        healBox.Collected += HealBoxPickUped;
    }

    private void HealBoxPickUped(HealBox healBox)
    {
        healBox.Collected -= HealBoxPickUped;
        Destroy(healBox.gameObject);
        Spawn();
    }
}

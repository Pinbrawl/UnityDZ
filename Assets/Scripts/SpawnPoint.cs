using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _endPoint;

    public void Spawn()
    {
        Enemy enemy = Instantiate(_enemy, transform.position, Quaternion.identity);
        enemy.InitEndPoint(_endPoint.position);
    }
}
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private int _minCubesCount;
    [SerializeField] private int _maxCubesCount;
    [SerializeField] private int _chance;
    [SerializeField] private Renderer _material;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private int _force;

    private int _minProcentage;
    private int _maxProcentage;

    private void Awake()
    {
        _material = GetComponent<Renderer>();
        _material.material.color = Random.ColorHSV();
        _minProcentage = 0;
        _maxProcentage = 100;
    }

    private void OnMouseDown()
    {
        if(_chance > Random.Range(_minProcentage, _maxProcentage + 1))
            SpawnCubes();
        Destroy(gameObject);
    }

    private void SpawnCubes()
    {
        int cubesCount = Random.Range(_minCubesCount, _maxCubesCount + 1);

        for(int i = 0; i < cubesCount; i++)
        {
            Cube cube = Instantiate(_prefab);
            cube.SetParameters(transform.localScale, _chance);
        }
    }

    private void SetParameters(Vector3 parentScale, int parentChance)
    {
        transform.localScale = parentScale / 2;
        _chance = parentChance / 2;

        int minDirection = 0;
        int maxDirection = 100;
        Vector3 direction = new Vector3(Random.Range(minDirection, maxDirection), Random.Range(minDirection, maxDirection), Random.Range(minDirection, maxDirection)).normalized;
        _rigidbody.AddForce(direction * _force, ForceMode.Impulse);
    }
}
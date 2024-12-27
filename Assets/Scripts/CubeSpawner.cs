using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private int _minCubesCount;
    [SerializeField] private int _maxCubesCount;
    [SerializeField] private List<Cube> _cubes;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private int _decrease;

    private int _minProcentage;
    private int _maxProcentage;

    private void Awake()
    {
        _minProcentage = 0;
        _maxProcentage = 100;
    }

    private void OnEnable()
    {
        foreach (Cube cube in _cubes)
            cube.Clicked += SpawnCubes;
    }

    private void OnDisable()
    {
        foreach (Cube cube in _cubes)
            cube.Clicked -= SpawnCubes;
    }

    private void SpawnCubes(Cube parentCube)
    {
        parentCube.Clicked -= SpawnCubes;

        if (parentCube.Chance >= UnityEngine.Random.Range(_minProcentage, _maxProcentage + 1))
        {
            List<Cube> newCubes = new List<Cube>();

            int cubesCount = Random.Range(_minCubesCount, _maxCubesCount + 1);

            for (int i = 0; i < cubesCount; i++)
            {
                Cube cube = Instantiate(_prefab, parentCube.transform.position, Quaternion.identity);
                cube.InitParameters(parentCube.transform.localScale / _decrease, parentCube.Chance / _decrease);

                cube.Clicked += SpawnCubes;
                _cubes.Add(cube);

                newCubes.Add(cube);
            }

            _exploder.Explode(newCubes);
        }
    }
}
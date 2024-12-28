using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private int _minCubesCount;
    [SerializeField] private int _maxCubesCount;
    [SerializeField] private int _decrease;

    public List<Cube> SpawnCubes(Cube parentCube)
    {
        List<Cube> newCubes = new List<Cube>();

        int cubesCount = Random.Range(_minCubesCount, _maxCubesCount + 1);

        for (int i = 0; i < cubesCount; i++)
        {
            Cube cube = Instantiate(_prefab, parentCube.transform.position, Quaternion.identity);
            cube.InitParameters(parentCube.transform.localScale / _decrease, parentCube.Chance / _decrease);

            newCubes.Add(cube);
        }

        return newCubes;
    }
}
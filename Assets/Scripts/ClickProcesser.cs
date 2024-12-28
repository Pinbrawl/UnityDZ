using System.Collections.Generic;
using UnityEngine;

public class ClickProcesser : MonoBehaviour
{
    [SerializeField] private List<Cube> _cubes;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private ColorChanger _colorChanger;

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
            cube.Clicked += ProcessClick;
    }

    private void OnDisable()
    {
        foreach (Cube cube in _cubes)
            cube.Clicked -= ProcessClick;
    }

    private void ProcessClick(Cube cube)
    {
        cube.Clicked -= ProcessClick;

        List<Cube> newCubes = new List<Cube>();

        if (cube.Chance >= Random.Range(_minProcentage, _maxProcentage))
            newCubes = _cubeSpawner.SpawnCubes(cube);

        foreach(Cube newCube in newCubes)
        {
            _exploder.Explode(newCube);
            _colorChanger.ChangeColor(newCube.Renderer);

            newCube.Clicked += ProcessClick;
        }
    }
}
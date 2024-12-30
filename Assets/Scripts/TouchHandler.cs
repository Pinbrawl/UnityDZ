using System.Collections.Generic;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    [SerializeField] private List<Plane> _planes;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private CubeRemover _cubeRemover;

    private void OnEnable()
    {
        foreach (Plane plane in _planes)
            plane.CubeTouch += CubeTouch;
    }

    private void OnDisable()
    {
        foreach (Plane plane in _planes)
            plane.CubeTouch -= CubeTouch;
    }

    private void CubeTouch(Cube cube)
    {
        if(cube.IsTouch == false)
        {
            cube.Touch();
            _colorChanger.ChangeColor(cube.Renderer);
            _cubeRemover.DelayedDelete(cube, _spawner.Pool);
        }
    }
}
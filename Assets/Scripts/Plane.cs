using System;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public event Action <Cube> CubeTouch;

    private void OnCollisionEnter(Collision collision)
    {
        Cube cube = collision.gameObject.GetComponent<Cube>();

        if (cube != null)
            CubeTouch.Invoke(cube);
    }
}
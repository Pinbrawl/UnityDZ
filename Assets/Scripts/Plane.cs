using System;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public event Action <Cube> CubeTouch;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Cube>())
            CubeTouch.Invoke(collision.gameObject.GetComponent<Cube>());
    }
}
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private int _force;

    public void Explode(List<Cube> cubes)
    {
        int minDirection = 0;
        int maxDirection = 100;
        foreach (Cube cube in cubes)
        {
            Vector3 direction = new Vector3(UnityEngine.Random.Range(minDirection, maxDirection), UnityEngine.Random.Range(minDirection, maxDirection), UnityEngine.Random.Range(minDirection, maxDirection)).normalized;
            cube.Rigidbody.AddForce(direction * _force, ForceMode.Impulse);
        }
    }
}
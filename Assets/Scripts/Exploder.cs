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
            int randomX = Random.Range(minDirection, maxDirection + 1);
            int randomY = Random.Range(minDirection, maxDirection + 1);
            int randomZ = Random.Range(minDirection, maxDirection + 1);

            Vector3 direction = new Vector3(randomX, randomY, randomZ).normalized;

            cube.Rigidbody.AddForce(direction * _force, ForceMode.Impulse);
        }
    }
}
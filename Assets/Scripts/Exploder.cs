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
            int RandomX = Random.Range(minDirection, maxDirection);
            int RandomY = Random.Range(minDirection, maxDirection);
            int RandomZ = Random.Range(minDirection, maxDirection);

            Vector3 direction = new Vector3(RandomX, RandomY, RandomZ).normalized;

            cube.Rigidbody.AddForce(direction * _force, ForceMode.Impulse);
        }
    }
}
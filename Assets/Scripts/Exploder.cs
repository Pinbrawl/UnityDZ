using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private int _force;

    public void Explode(Cube cube)
    {
        int minDirection = 0;
        int maxDirection = 100;

        int randomX = Random.Range(minDirection, maxDirection + 1);
        int randomY = Random.Range(minDirection, maxDirection + 1);
        int randomZ = Random.Range(minDirection, maxDirection + 1);

        Vector3 direction = new Vector3(randomX, randomY, randomZ).normalized;

        cube.Rigidbody.AddForce(direction * _force, ForceMode.Impulse);
    }
}
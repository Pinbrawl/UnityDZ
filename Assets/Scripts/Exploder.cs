using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private int _force;
    [SerializeField] private int _radius;

    public void Explode(Cube cube)
    {
        cube.Rigidbody.AddExplosionForce(_force * cube.ExplodeMultiplier, cube.transform.position, _radius * cube.ExplodeMultiplier);
    }
}
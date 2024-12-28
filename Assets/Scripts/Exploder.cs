using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private int _force;
    [SerializeField] private int _radius;

    public void Explode(Cube cube)
    {
        Collider[] cubesInRadius = Physics.OverlapSphere(cube.transform.position, _radius * cube.ExplodeMultiplier);

        foreach(Collider cubeInRadius in cubesInRadius)
            if(cubeInRadius.GetComponent<Cube>())
                cubeInRadius.GetComponent<Cube>().Rigidbody.AddExplosionForce(_force * cube.ExplodeMultiplier, cube.transform.position, _radius * cube.ExplodeMultiplier);
    }
}
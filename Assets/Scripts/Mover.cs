using UnityEngine;

public class Mover : AbstractTransformer
{
    protected override void Transform()
    {
        transform.Translate(_speed * Vector3.forward * Time.deltaTime);
    }
}
using UnityEngine;

public class Rotator : AbstractTransformer
{
    protected override void Transform()
    {
        transform.Rotate(0, _speed * Time.deltaTime, 0);
    }
}
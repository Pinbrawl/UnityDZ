using UnityEngine;

public class Increaser : AbstractTransformer
{
    protected override void Transform()
    {
        transform.localScale = new Vector3(transform.localScale.x + (_speed * Time.deltaTime), transform.localScale.y + (_speed * Time.deltaTime), transform.localScale.z + (_speed * Time.deltaTime));
    }
}
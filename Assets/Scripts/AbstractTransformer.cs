using UnityEngine;

public abstract class AbstractTransformer : MonoBehaviour
{
    [SerializeField] protected float _speed;

    private void Update()
    {
        Transform();
    }

    protected abstract void Transform();
}
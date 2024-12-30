using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    public ObjectPool<GameObject> Pool;
    public Renderer Renderer { get; private set; }

    public bool IsTouch { get; private set; }

    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
    }

    public void Touch()
    {
        IsTouch = true;
    }

    public void Refresh()
    {
        IsTouch = false;
    }

    public void ReturnInPool()
    {
        Pool.Release(gameObject);
    }
}
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    public Renderer Renderer { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    public bool IsTouch { get; private set; }

    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Touch()
    {
        IsTouch = true;
    }

    public void Refresh()
    {
        IsTouch = false;
    }
}
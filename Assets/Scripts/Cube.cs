using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    public event Action<Cube> Clicked;

    [field:SerializeField] public int Chance { get; private set; }
    public Renderer Renderer { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        Clicked?.Invoke(this);

        Destroy(gameObject);
    }

    public void InitParameters(Vector3 parentScale, int parentChance)
    {
        transform.localScale = parentScale;
        Chance = parentChance;
    }
}
using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    public event Action<Cube> Clicked;

    [field:SerializeField] public int Chance {  get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        this.Rigidbody = GetComponent<Rigidbody>();

        ChangeColor();
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

    private void ChangeColor()
    {
        _renderer.material.color = UnityEngine.Random.ColorHSV();
    }
}
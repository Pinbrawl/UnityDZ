using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    [field:SerializeField] public int Chance {  get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    public event Action<Cube> Clicked;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();

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
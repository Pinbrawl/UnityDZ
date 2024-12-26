using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;

    public event Action<Cube> ClickedOnCube;

    [field:SerializeField] public int Chance {  get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();

        ChangeColor();
    }

    private void OnMouseDown()
    {
        ClickedOnCube?.Invoke(this);

        Destroy(gameObject);
    }

    public void SetParameters(Vector3 parentScale, int parentChance)
    {
        transform.localScale = parentScale / 2;
        Chance = parentChance / 2;
    }

    private void ChangeColor()
    {
        _renderer.material.color = UnityEngine.Random.ColorHSV();
    }
}
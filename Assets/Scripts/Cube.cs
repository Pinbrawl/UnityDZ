using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _minDelayDelete;
    [SerializeField] private float _maxDelayDelete;

    public event Action<Cube> Released;

    public Renderer Renderer { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public bool IsTouch { get; private set; }

    private void Awake()
    {
        Renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Plane plane = collision.gameObject.GetComponent<Plane>();

        if(plane != null && IsTouch == false)
        {
            IsTouch = true;
            ChangeColor();
            DelayedRelease();
        }
    }

    public void Refresh()
    {
        IsTouch = false;
    }

    private void DelayedRelease()
    {
        float randomDelay = UnityEngine.Random.Range(_minDelayDelete, _maxDelayDelete);
        StartCoroutine(Wait(randomDelay));
    }

    private IEnumerator Wait(float delay)
    {
        yield return new WaitForSeconds(delay);

        Released?.Invoke(this);
    }

    private void ChangeColor()
    {
        Renderer.material.color = UnityEngine.Random.ColorHSV();
    }
}
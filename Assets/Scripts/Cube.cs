using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _minDelayDelete;
    [SerializeField] private float _maxDelayDelete;

    public event Action<GameObject> ReleaseMe;

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
            DelayedDelete();
        }
    }

    public void Refresh()
    {
        IsTouch = false;
    }

    private void DelayedDelete()
    {
        float randomDelay = UnityEngine.Random.Range(_minDelayDelete, _maxDelayDelete);
        StartCoroutine(Delay(randomDelay));
    }

    private IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);

        ReleaseMe?.Invoke(gameObject);
    }

    private void ChangeColor()
    {
        Renderer.material.color = UnityEngine.Random.ColorHSV();
    }
}
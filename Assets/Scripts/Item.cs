using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Item : MonoBehaviour
{
    [SerializeField] protected CollectEffect _collectEffect;

    public virtual void Remove()
    {
        Instantiate(_collectEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
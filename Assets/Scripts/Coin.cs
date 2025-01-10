using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour
{
    [SerializeField] private CollectEffect _collectEffect;

    public event Action<Coin> PickUped;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if(player != null)
        {
            PickUped?.Invoke(this);
            Instantiate(_collectEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
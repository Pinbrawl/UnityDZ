using System;
using UnityEngine;

public class ItemPickUper : MonoBehaviour
{
    public event Action PickUpCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Item>(out Item item))
        {
            Coin coin;

            if (item.TryGetComponent<Coin>(out coin))
                PickUpCoin?.Invoke();

            item.Remove();
        }
    }
}
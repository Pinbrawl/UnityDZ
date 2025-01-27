using System;
using UnityEngine;

public class ItemPickUper : MonoBehaviour
{
    public event Action PickUpCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item;

        if (collision.gameObject.TryGetComponent<Item>(out item))
        {
            Coin coin;

            if (item.TryGetComponent<Coin>(out coin))
                PickUpCoin?.Invoke();

            item.Remove();
        }
    }
}
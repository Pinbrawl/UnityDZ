using System;
using UnityEngine;

public class ItemPickUper : MonoBehaviour
{
    public event Action PickUpCoin;
    public event Action PickUpHealBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Item item))
        {
            if (item is Coin)
                PickUpCoin?.Invoke();
            else if(item is HealBox)
                PickUpHealBox?.Invoke();

            item.Remove();
        }
    }
}
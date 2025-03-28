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
            if (item.TryGetComponent<Coin>(out _))
                PickUpCoin?.Invoke();

            if(item.TryGetComponent<HealBox>(out _))
                PickUpHealBox?.Invoke();

            item.Remove();
        }
    }
}
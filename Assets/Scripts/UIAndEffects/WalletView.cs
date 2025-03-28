using UnityEngine;

public class WalletView : View
{
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _wallet.CoinChanged += Print;
    }

    private void OnDisable()
    {
        _wallet.CoinChanged -= Print;
    }
}

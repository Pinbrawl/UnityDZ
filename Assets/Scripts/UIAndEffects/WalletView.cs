using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] protected TextMeshProUGUI _textForCount;
    [SerializeField] private string _baseStringForPrint;

    private void OnEnable()
    {
        _wallet.CoinChanged += Print;
    }

    private void OnDisable()
    {
        _wallet.CoinChanged -= Print;
    }

    protected virtual void Print(int count)
    {
        _textForCount.text = _baseStringForPrint + ": " + count;
    }
}

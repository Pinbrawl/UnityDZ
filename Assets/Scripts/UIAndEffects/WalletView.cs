using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private string _baseStringForPrint;
    [SerializeField] private TextMeshProUGUI _textForCount;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _wallet.CoinChanged += Print;
    }

    private void OnDisable()
    {
        _wallet.CoinChanged -= Print;
    }

    private void Print(int health)
    {
        _textForCount.text = _baseStringForPrint + ": " + health;
    }
}

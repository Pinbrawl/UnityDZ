using TMPro;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private string _baseStringForPrint;
    [SerializeField] private TextMeshProUGUI _textForCount;

    protected void Print(int count)
    {
        _textForCount.text = _baseStringForPrint + ": " + count;
    }
}

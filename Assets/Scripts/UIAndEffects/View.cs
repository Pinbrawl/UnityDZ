using TMPro;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _textForCount;

    [SerializeField] private string _baseStringForPrint;

    protected virtual void Print(int count)
    {
        _textForCount.text = _baseStringForPrint + ": " + count;
    }
}

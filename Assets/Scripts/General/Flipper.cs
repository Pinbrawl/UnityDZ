using UnityEngine;

public class Flipper : MonoBehaviour
{
    private float _flipBorder;
    private int _degreesForNotFlip;
    private int _degreesForFlip;

    private Quaternion _rotateForNotFlip;
    private Quaternion _rotateForFlip;

    private void Awake()
    {
        _flipBorder = 0f;
        _degreesForNotFlip = 0;
        _degreesForFlip = 180;
        _rotateForNotFlip = Quaternion.Euler(transform.rotation.x, _degreesForNotFlip, transform.rotation.z);
        _rotateForFlip = Quaternion.Euler(transform.rotation.x, _degreesForFlip, transform.rotation.z);
    }

    public void Flip(float speedNow)
    {
        if (speedNow > _flipBorder)
            transform.rotation = _rotateForNotFlip;
        else if (speedNow < _flipBorder)
            transform.rotation = _rotateForFlip;
    }
}
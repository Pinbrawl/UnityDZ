using UnityEngine;

public class Flipper : MonoBehaviour
{
    private float _flipBorder;

    private void Awake()
    {
        _flipBorder = 0f;
    }

    public void Flip(float speedNow)
    {
        int degreesForNotFlip = 0;
        int degreesForFlip = 180;

        Quaternion rotateForNotFlip = Quaternion.Euler(transform.rotation.x, degreesForNotFlip, transform.rotation.z);
        Quaternion rotateForFlip = Quaternion.Euler(transform.rotation.x, degreesForFlip, transform.rotation.z);

        if (speedNow > _flipBorder)
            transform.rotation = rotateForNotFlip;
        else if (speedNow < _flipBorder)
            transform.rotation = rotateForFlip;
    }
}
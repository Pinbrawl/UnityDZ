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
        int rotateForFlip = 180;

        if (speedNow > _flipBorder)
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        else if (speedNow < _flipBorder)
            transform.rotation = Quaternion.Euler(transform.rotation.x, rotateForFlip, transform.rotation.z);
    }
}

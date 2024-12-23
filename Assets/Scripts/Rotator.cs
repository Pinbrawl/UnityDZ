using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private int _speed;

    private void Update()
    {
        transform.Rotate(0, _speed * Time.deltaTime, 0);
    }
}
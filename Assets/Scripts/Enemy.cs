using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _speed;

    private Vector3 _direction;

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    public void InitDirection(Vector3 direction)
    {
        _direction = direction;
    }
}
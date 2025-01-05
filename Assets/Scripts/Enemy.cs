using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _speed;

    public Vector3 Direction;

    private void Update()
    {
        transform.Translate(Direction * _speed * Time.deltaTime);
    }
}
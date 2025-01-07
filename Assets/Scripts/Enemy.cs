using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _speed;

    private Vector3 _endPoint;

    private void Update()
    {
        Vector3 direction = (_endPoint - transform.position).normalized;
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    public void InitEndPoint(Vector3 endPoint)
    {
        _endPoint = endPoint;
    }
}
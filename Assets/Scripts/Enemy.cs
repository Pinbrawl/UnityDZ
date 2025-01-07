using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int _speed;

    protected Vector3 _endPoint;

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
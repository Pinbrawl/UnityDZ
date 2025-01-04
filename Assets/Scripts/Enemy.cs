using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _speed;

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JumpEnemy : Enemy
{
    [SerializeField] private string _groundsTag = "Ground";
    [SerializeField] private int _jumpForce;
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 direction = new Vector3(_endPoint.x - transform.position.x, 0, _endPoint.x - transform.position.x).normalized;
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == _groundsTag)
            Jump();
    }

    private void Jump()
    {
        _rigidbody.AddForce(new Vector3(0, _jumpForce, 0));
    }
}
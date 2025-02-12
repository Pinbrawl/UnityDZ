using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    public float SpeedNow;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Run(float direction)
    {
        SpeedNow = _speed * direction;
        transform.Translate(transform.right * (SpeedNow * Time.deltaTime));
    }

    public void Jump()
    {
        _rigidbody2D.velocity = Vector2.up * _jumpForce;
    }
}

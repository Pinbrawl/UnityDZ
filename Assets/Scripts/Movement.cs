using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _finalPoint;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.MoveTowards(transform.position.z, _finalPoint.transform.position.z, _speed * Time.deltaTime));
    }
}
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _finalPoint;

    private void Update()
    {
        float ZCoordinate = Mathf.MoveTowards(transform.position.z, _finalPoint.transform.position.z, _speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, ZCoordinate);
    }
}
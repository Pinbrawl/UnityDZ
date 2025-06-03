using UnityEngine;

public class BarFollower : MonoBehaviour
{
    [SerializeField] private Transform _object;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        if(_object == null)
            Destroy(gameObject);
        
        transform.position = _object.position + _offset;
    }
}

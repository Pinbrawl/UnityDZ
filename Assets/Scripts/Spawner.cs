using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private float _repeatRate;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;

    private ObjectPool<GameObject> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<GameObject>(
        createFunc: CreateFunc,
        actionOnGet: ActionOnGet,
        actionOnRelease: (obj) => obj.SetActive(false),
        actionOnDestroy: Destroy,
        collectionCheck: true,
        defaultCapacity: _poolCapacity,
        maxSize: _poolMaxSize);
    }

    private void Start()
    {
        InvokeRepeating(nameof(GetCube), 0.0f, _repeatRate);
    }

    private GameObject CreateFunc()
    {
        Cube cube = Instantiate(_cube).GetComponent<Cube>();
        cube.Pool = _pool;

        return cube.gameObject;
    }

    private void ActionOnGet(GameObject obj)
    {
        float randomPositionX = Random.Range(transform.position.x - transform.localScale.x, transform.position.x + transform.localScale.x);
        float randomPositionY = Random.Range(transform.position.y - transform.localScale.y, transform.position.y + transform.localScale.y);
        float randomPositionZ = Random.Range(transform.position.z - transform.localScale.z, transform.position.z + transform.localScale.z);

        Vector3 randomPosition = new Vector3(randomPositionX, randomPositionY, randomPositionZ);

        obj.transform.position = randomPosition;
        obj.transform.rotation = Quaternion.identity;
        obj.GetComponent<Cube>().Renderer.material.color = _cube.GetComponent<Renderer>().sharedMaterial.color;
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        obj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        obj.GetComponent<Cube>().Refresh();
        obj.SetActive(true);
    }

    private void GetCube()
    {
        _pool.Get();
    }
}
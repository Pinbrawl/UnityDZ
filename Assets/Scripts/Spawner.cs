using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private float _repeatRate;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;

    public ObjectPool<GameObject> Pool { get; private set; }

    private void Awake()
    {
        Pool = new ObjectPool<GameObject>(
        createFunc: CreateFunc,
        actionOnGet: DoOnGet,
        actionOnRelease: (obj) => obj.gameObject.SetActive(false),
        actionOnDestroy: (obj) => Destroy(obj),
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
        Cube cube = Instantiate(_cube);
        cube.ReleaseMe += ReleaseCube;

        return cube.gameObject;
    }

    private void DoOnGet(GameObject obj)
    {
        float randomPositionX = Random.Range(transform.position.x - transform.localScale.x, transform.position.x + transform.localScale.x);
        float randomPositionY = Random.Range(transform.position.y - transform.localScale.y, transform.position.y + transform.localScale.y);
        float randomPositionZ = Random.Range(transform.position.z - transform.localScale.z, transform.position.z + transform.localScale.z);

        Vector3 randomPosition = new Vector3(randomPositionX, randomPositionY, randomPositionZ);

        Cube cube = obj.GetComponent<Cube>();

        cube.transform.position = randomPosition;
        cube.transform.rotation = Quaternion.identity;
        cube.Renderer.material.color = _cube.GetComponent<Renderer>().sharedMaterial.color;
        cube.Rigidbody.velocity = Vector3.zero;
        cube.Rigidbody.angularVelocity = Vector3.zero;
        cube.Refresh();
        obj.SetActive(true);
    }

    private void GetCube()
    {
        Pool.Get();
    }

    private void DoOnDestroy(GameObject obj)
    {
        Cube cube = obj.GetComponent<Cube>();
        cube.ReleaseMe -= ReleaseCube;

        Destroy(obj);
    }

    private void ReleaseCube(GameObject obj)
    {
        Pool.Release(obj);
    }
}
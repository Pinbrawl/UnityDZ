using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private float _repeatRate;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;

    public ObjectPool<Cube> Pool { get; private set; }

    private void Awake()
    {
        Pool = new ObjectPool<Cube>(
        createFunc: CreateCube,
        actionOnGet: DoOnGet,
        actionOnRelease: (obj) => obj.gameObject.SetActive(false),
        actionOnDestroy: (obj) => Destroy(obj),
        collectionCheck: true,
        defaultCapacity: _poolCapacity,
        maxSize: _poolMaxSize);
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnCube), 0.0f, _repeatRate);
    }

    private Cube CreateCube()
    {
        Cube cube = Instantiate(_cube);
        cube.Released += ReleaseCube;

        return cube;
    }

    private void DoOnGet(Cube obj)
    {
        float randomPositionX = Random.Range(transform.position.x - transform.localScale.x, transform.position.x + transform.localScale.x);
        float randomPositionY = Random.Range(transform.position.y - transform.localScale.y, transform.position.y + transform.localScale.y);
        float randomPositionZ = Random.Range(transform.position.z - transform.localScale.z, transform.position.z + transform.localScale.z);

        Vector3 randomPosition = new Vector3(randomPositionX, randomPositionY, randomPositionZ);

        obj.transform.position = randomPosition;
        obj.transform.rotation = Quaternion.identity;

        _cube.Init();
        obj.Renderer.material.color = _cube.Renderer.sharedMaterial.color;
        
        obj.Rigidbody.velocity = Vector3.zero;
        obj.Rigidbody.angularVelocity = Vector3.zero;

        obj.Refresh();

        obj.gameObject.SetActive(true);
    }

    private void SpawnCube()
    {
        Pool.Get();
    }

    private void DoOnDestroy(GameObject obj)
    {
        Cube cube = obj.GetComponent<Cube>();
        cube.Released -= ReleaseCube;

        Destroy(obj);
    }

    private void ReleaseCube(Cube obj)
    {
        Pool.Release(obj);
    }
}
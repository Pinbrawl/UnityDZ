using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class CubeRemover : MonoBehaviour
{
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;

    public void DelayedDelete(Cube cube, ObjectPool<GameObject> pool)
    {
        float randomDelay = Random.Range(_minDelay, _maxDelay);
        StartCoroutine(Delay(cube, pool, randomDelay));
    }

    private IEnumerator Delay(Cube cube, ObjectPool<GameObject> pool, float delay)
    {
        yield return new WaitForSeconds(delay);

        pool.Release(cube.gameObject);
    }
}
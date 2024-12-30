using System.Collections;
using UnityEngine;

public class CubeRemover : MonoBehaviour
{
    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;

    public void DelayedDelete(Cube cube)
    {
        float randomDelay = Random.Range(_minDelay, _maxDelay);
        StartCoroutine(Delay(cube, randomDelay));
    }

    private IEnumerator Delay(Cube cube, float delay)
    {
        yield return new WaitForSeconds(delay);

        cube.ReturnInPool();
    }
}
using System.Collections;
using UnityEngine;

public class CubeRemover : MonoBehaviour
{
    [SerializeField] private float minDelay;
    [SerializeField] private float maxDelay;

    public void DelayedDelete(Cube cube)
    {
        float randomDelay = Random.Range(minDelay, maxDelay);
        StartCoroutine(Delay(cube, randomDelay));
    }

    private IEnumerator Delay(Cube cube, float delay)
    {
        yield return new WaitForSeconds(delay);

        cube.ReturnInPool();
    }
}
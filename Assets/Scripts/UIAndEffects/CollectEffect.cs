using System.Collections;
using UnityEngine;

public class CollectEffect : MonoBehaviour
{
    [SerializeField] private float _lifeSeconds;

    private void Start()
    {
        StartCoroutine(Collect());
    }

    private IEnumerator Collect()
    {
        yield return new WaitForSeconds(_lifeSeconds);

        Destroy(gameObject);
    }
}
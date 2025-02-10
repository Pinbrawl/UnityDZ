using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(SpriteRenderer))]
public class Immortalitier : MonoBehaviour
{
    [SerializeField] private float _secondsImmortality;
    [SerializeField] private float _secondsForBlinking;

    private Health _health;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public IEnumerator DoImmortality()
    {
        var blinkingTime = new WaitForSeconds(_secondsForBlinking);
        float timeImmortality = _secondsImmortality;
        _health.IsImmortality = true;

        while (timeImmortality > 0)
        {
            _spriteRenderer.enabled = !_spriteRenderer.enabled;

            if (timeImmortality <= _secondsForBlinking)
            {
                yield return new WaitForSeconds(timeImmortality);

                timeImmortality = 0;
            }
            else
            {
                yield return blinkingTime;

                timeImmortality -= _secondsForBlinking;
            }
        }

        _health.IsImmortality = false;
        _spriteRenderer.enabled = true;
    }
}

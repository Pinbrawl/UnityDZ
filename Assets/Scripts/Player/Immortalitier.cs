using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Immortalitier : MonoBehaviour
{
    [SerializeField] private float _secondsImmortality;
    [SerializeField] private float _secondsForBlinking;

    private SpriteRenderer _spriteRenderer;

    public event Action<bool> ImmortalityChanged;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public IEnumerator DoImmortality()
    {
        var blinkingTime = new WaitForSeconds(_secondsForBlinking);
        float timeImmortality = _secondsImmortality;

        ImmortalityChanged?.Invoke(true);

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

        ImmortalityChanged?.Invoke(false);

        _spriteRenderer.enabled = true;
    }
}

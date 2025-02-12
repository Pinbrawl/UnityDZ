using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerCondition))]
public class Immortalitier : MonoBehaviour
{
    [SerializeField] private float _secondsImmortality;
    [SerializeField] private float _secondsForBlinking;

    private PlayerCondition _playerCondition;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _playerCondition = GetComponent<PlayerCondition>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public IEnumerator DoImmortality()
    {
        var blinkingTime = new WaitForSeconds(_secondsForBlinking);
        float timeImmortality = _secondsImmortality;
        _playerCondition.IsImmortality = true;

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

        _playerCondition.IsImmortality = false;
        _spriteRenderer.enabled = true;
    }
}

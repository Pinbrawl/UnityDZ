using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _step;

    private bool _isPlaying;

    private void Start()
    {
        _isPlaying = true;
        StartCoroutine(Countdown());
    }

    private void Update()
    {
        TimersPlayer();
    }

    private IEnumerator Countdown()
    {
        var wait = new WaitForSeconds(_delay);
        float count = 0;

        while(true)
        {
            if(_isPlaying)
            {
                DisplayCountdown(count++);
                yield return wait;
            }
            else
            {
                yield return null;
            }
        }
    }

    private void DisplayCountdown(float count)
    {
        Debug.Log(count);
    }

    private void TimersPlayer()
    {
        if (Input.GetMouseButtonDown(0))
            _isPlaying = !_isPlaying;
    }
}
using System;
using System.Collections;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private float _speedTurn;
    [SerializeField] private float _secondsStepForTurn;
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _minVolume;
    [SerializeField] private Detector _detector;
    [SerializeField] private AudioSource _sound;

    private int _objectsInHouse;
    private Coroutine _coroutine;

    private void Awake()
    {
        _objectsInHouse = 0;
    }

    private void OnEnable()
    {
        _detector.ObjectEnter += CheckWhenEnter;
        _detector.ObjectExit += CheckWhenExit;
    }

    private void OnDisable()
    {
        _detector.ObjectEnter -= CheckWhenEnter;
        _detector.ObjectExit -= CheckWhenExit;
    }

    private void CheckWhenEnter()
    {
        _objectsInHouse++;

        if(_objectsInHouse == 1)
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(ChangeVolume(_maxVolume));
        }
    }

    private void CheckWhenExit()
    {
        _objectsInHouse--;

        if(_objectsInHouse == 0)
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(ChangeVolume(_minVolume));
        }
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        var time = new WaitForSeconds(_secondsStepForTurn);
        
        if(targetVolume > _sound.volume)
            _sound.Play();

        while (targetVolume > _sound.volume)
        {
            yield return time;

            _sound.volume = Math.Min(targetVolume, _sound.volume + _speedTurn);
        }

        while (targetVolume < _sound.volume)
        {
            yield return time;

            _sound.volume = Math.Max(targetVolume, _sound.volume - _speedTurn);
        }

        if (_sound.volume == 0)
            _sound.Stop();
    }
}
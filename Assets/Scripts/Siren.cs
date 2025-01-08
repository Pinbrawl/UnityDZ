using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private float _speedTurn;
    [SerializeField] private float _secondsStep;
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _minVolume;
    [SerializeField] private List<Detectorator> _detectorator;
    [SerializeField] private AudioSource _sound;

    private bool _isPlaying;

    private void Awake()
    {
        _isPlaying = false;
    }

    private void OnEnable()
    {
        foreach (Detectorator detectorator in _detectorator)
            detectorator.Detection += SwitchSiren;
    }

    private void OnDisable()
    {
        foreach (Detectorator detectorator in _detectorator)
            detectorator.Detection -= SwitchSiren;
    }

    private void SwitchSiren()
    {
        _isPlaying = !_isPlaying;

        if (_isPlaying)
            StartCoroutine(TurnUpVolume());
        else
            StartCoroutine(TurnDownVolume());
    }

    private IEnumerator TurnUpVolume()
    {
        var time = new WaitForSeconds(_secondsStep);

        while(_sound.volume < _maxVolume)
        {
            yield return time;

            _sound.volume = Math.Min(_maxVolume, _sound.volume + _speedTurn);
        }

        yield break;
    }

    private IEnumerator TurnDownVolume()
    {
        var time = new WaitForSeconds(_secondsStep);

        while (_sound.volume > _minVolume)
        {
            yield return time;

            _sound.volume = Math.Max(_minVolume, _sound.volume - _speedTurn);
        }

        yield break;
    }
}
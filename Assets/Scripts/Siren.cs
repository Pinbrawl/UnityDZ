using System;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private float _speedTurnUp;
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _minVolume;
    [SerializeField] private List<Exit> _exits;
    [SerializeField] private AudioSource _sound;

    private bool _isPlaying;

    private void Awake()
    {
        _isPlaying = false;
    }

    private void FixedUpdate()
    {
        if(_isPlaying && _sound.volume < _maxVolume)
            _sound.volume = Math.Min(_maxVolume, _sound.volume + _speedTurnUp);

        if (_isPlaying == false && _sound.volume > _minVolume)
            _sound.volume = Math.Max(_minVolume, _sound.volume - _speedTurnUp);
    }

    private void OnEnable()
    {
        foreach (Exit exit in _exits)
            exit.TriggerPassed += SwitchSiren;
    }

    private void OnDisable()
    {
        foreach (Exit exit in _exits)
            exit.TriggerPassed -= SwitchSiren;
    }

    private void SwitchSiren()
    {
        _isPlaying = !_isPlaying;
    }
}
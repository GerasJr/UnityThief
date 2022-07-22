using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmAudio;
    private Coroutine _changeVolumeJob;
    private int _minVolume = 0;
    private int _maxVolume = 100;
    private float _valueSpeed = 0.2f;

    public void Play()
    {
        if(_changeVolumeJob != null)
        {
            StopCoroutine(_changeVolumeJob);
        }

        _alarmAudio.Play();
        _changeVolumeJob = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void Stop()
    {
        if (_changeVolumeJob != null)
        {
            StopCoroutine(_changeVolumeJob);
        }

        _changeVolumeJob = StartCoroutine(ChangeVolume(_minVolume));

        if(_alarmAudio.volume == _minVolume)
        {
            _alarmAudio.Stop();
        }
    }

    public IEnumerator ChangeVolume(int targetVolume)
    {
        while (_alarmAudio.volume != targetVolume)
        {
            _alarmAudio.volume = Mathf.MoveTowards(_alarmAudio.volume, targetVolume, _valueSpeed * Time.deltaTime);
            yield return null;
        }
    }
}


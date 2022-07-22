using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmAudio;
    private int _minVolume = 0;
    private int _maxVolume = 100;
    private float _valueSpeed = 0.2f;

    public void Play()
    {
        StopAllCoroutines();
        _alarmAudio.Play();
        var changeVolumeJob = StartCoroutine(ChangeVolume(_maxVolume));

        if (_alarmAudio.volume == _maxVolume)
        {
            StopCoroutine(changeVolumeJob);
        }
    }

    public void Stop()
    {
        StopAllCoroutines();
        var changeVolumeJob = StartCoroutine(ChangeVolume(_minVolume));

        if(_alarmAudio.volume == _minVolume)
        {
            StopCoroutine(changeVolumeJob);
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


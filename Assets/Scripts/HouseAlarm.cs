using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseAlarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmAudio;
    [SerializeField] private bool _isRobbery = false;
    private float _valueSpeed = 0.2f;
    private int _maxVolume = 100;
    private int _minVolume = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Thief>())
        {
            _isRobbery = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isRobbery = false;
    }

    private void Update()
    {
        if (_isRobbery)
        {
            _alarmAudio.volume = Mathf.MoveTowards(_alarmAudio.volume, _maxVolume, _valueSpeed * Time.deltaTime);
        }
        else
        {
            _alarmAudio.volume = Mathf.MoveTowards(_alarmAudio.volume, _minVolume, _valueSpeed * Time.deltaTime);
        }
    }
}

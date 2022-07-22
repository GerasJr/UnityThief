using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecuritySystem : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Thief>())
        {
            _alarm.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _alarm.Stop();
    }
}

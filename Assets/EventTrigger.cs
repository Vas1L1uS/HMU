using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] private Collider _player;
    [SerializeField] private GameObject _timelineD;
    [SerializeField] private GameObject _timelineActivate;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision == _player)
        {
            _timelineD.SetActive(false);
            _timelineActivate.SetActive(true);
        }
    }
}

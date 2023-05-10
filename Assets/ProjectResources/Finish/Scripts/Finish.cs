using System;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public event Action PlayerEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GlobalConstVars.PLAYER_TAG))
        {
            PlayerEntered?.Invoke();
        }
    }
}

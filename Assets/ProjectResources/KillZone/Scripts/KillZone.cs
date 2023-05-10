using System;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public event Action PlayerEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(GlobalConstVars.PLAYER_TAG))
        {
            PlayerEntered?.Invoke();
        }
    }
}

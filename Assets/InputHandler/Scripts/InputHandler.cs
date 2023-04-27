using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;

    private void Update()
    {
        var touches = Input.touches;

        if (touches.Length > 0)
        {
            _player.SetVectorVelocity(new Vector3(touches[0].deltaPosition.x, 0, touches[0].deltaPosition.y).normalized);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private PlayerMovement _player;
    private JoystickManager _joystickManager;

    private void Update()
    {
        if (Input.touches.Length > 0)
        {
            _player.SetVectorVelocity(_joystickManager.GetTouchVector());
        }
    }

    public void SetSettings(PlayerMovement player, JoystickManager joystickManager)
    {
        _player = player;
        _joystickManager = joystickManager;
    }
}
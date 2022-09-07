using System;
using UnityEngine;

public class PlayerJoystickInput : MonoBehaviour
{
    private bool _moving;
    private Vector2 _position;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _moving = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _moving = false;
        }

        _position = Input.mousePosition;
    }

    public bool Moving()
    {
        return _moving;
    }

    public Vector2 GetPosition()
    {
        if (Moving() == false)
            throw new InvalidOperationException(nameof(GetPosition));

        return _position;
    }
}

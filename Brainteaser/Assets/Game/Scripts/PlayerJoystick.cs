using UnityEngine;

public class PlayerJoystick : MonoBehaviour
{
    [SerializeField] private PlayerJoystickInput _playerJoystickInput;
    [SerializeField] private Character _character;
    [SerializeField] private RectTransform _buttonBackground;
    [SerializeField] private RectTransform _button;
    [SerializeField] private float _maxDifferenceMovePositionsInPixels;

    private bool _hasStartedMove;
    private Vector2 _startMovePosition;
    private Vector2 _currentMovePosition;

    private void Update()
    {
        if (_playerJoystickInput.Moving())
        {
            if (_hasStartedMove)
            {
                _currentMovePosition = _playerJoystickInput.GetPosition();
                _button.position = GetButtonPosition();

                var differenceMovePositions = GetDifferenceMovePositions();
                _character.Move(differenceMovePositions / _maxDifferenceMovePositionsInPixels);
            }
            else
            {
                _hasStartedMove = true;

                _startMovePosition = _playerJoystickInput.GetPosition();
                _currentMovePosition = _startMovePosition;

                _buttonBackground.position = _startMovePosition;
                _button.position = GetButtonPosition();

                _buttonBackground.gameObject.SetActive(true);
                _button.gameObject.SetActive(true);
            }
        }
        else if (_hasStartedMove)
        {
            _hasStartedMove = false;

            _buttonBackground.gameObject.SetActive(false);
            _button.gameObject.SetActive(false);

            _character.StopMove();
        }
    }

    private Vector2 GetDifferenceMovePositions()
    {
        return Vector2.ClampMagnitude(_currentMovePosition - _startMovePosition, _maxDifferenceMovePositionsInPixels);
    }

    private Vector2 GetButtonPosition()
    {
        return _startMovePosition + GetDifferenceMovePositions();
    }
}

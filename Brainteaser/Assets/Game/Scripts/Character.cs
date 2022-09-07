using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed;

    private static readonly string _movingSpeedParameterName = "Speed";

    public Vector3 Position => transform.position;

    public void Move(Vector2 speed)
    {
        var difference = new Vector3(speed.x, 0, speed.y) * _moveSpeed * Time.deltaTime;
        transform.position += difference;
        transform.rotation = Quaternion.LookRotation(difference);
        _animator.SetFloat(_movingSpeedParameterName, speed.magnitude);
    }

    public void StopMove()
    {
        _animator.SetFloat(_movingSpeedParameterName, 0);
    }
}

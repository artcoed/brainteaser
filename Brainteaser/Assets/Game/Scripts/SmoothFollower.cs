using UnityEngine;

public class SmoothFollower : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Vector3 _savedDifferencePositions;

    public void SaveDifferencePositions(Vector3 position)
    {
        _savedDifferencePositions = position - transform.position;
    }

    public void Move(Vector3 position)
    {
        var desiredPosition = position - _savedDifferencePositions;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, _moveSpeed * Time.deltaTime);
    }
}

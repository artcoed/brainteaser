using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private SmoothFollower _smoothFollower;

    private void Awake()
    {
        _smoothFollower.SaveDifferencePositions(_character.Position);
    }

    private void Update()
    {
        _smoothFollower.Move(_character.Position);
    }
}

using UnityEngine;

public abstract class UnitMovable : MonoBehaviour, IMovable
{
    public abstract void Move(Vector2 direction);
}

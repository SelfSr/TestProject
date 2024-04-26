using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class UnitMovableRigidbody : UnitMovable
{
    private Rigidbody2D rb;

    public float speed = 10f;

    public void Init()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void Move(Vector2 direction)
    {
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }
}
using UnityEngine;

public class KeyboardInput : IInputService
{
    public Vector2 GetAxis()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        return new Vector2(horizontal, vertical);
    }
}
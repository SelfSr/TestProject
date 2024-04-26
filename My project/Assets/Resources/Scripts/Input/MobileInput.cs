using UnityEngine;

public class MobileInput : IInputService
{
    private float horizontal;
    private float vertical;

    private Joystick _joystick;

    public MobileInput(Joystick joystick)
    {
        _joystick = joystick;
    }
    public Vector2 GetAxis()
    {
        horizontal = _joystick.Horizontal;
        vertical = _joystick.Vertical;
        return new Vector2(horizontal, vertical);
    }
}
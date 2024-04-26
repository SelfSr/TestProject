using UnityEngine;

public class UnitPlayerMovement
{
    private readonly IMovable unitMoveable;
    private readonly IInputService inputService;

    private Joystick mobileJoystick;

    public UnitPlayerMovement(IMovable movable, Joystick joystick)
    {
        unitMoveable = movable;
        mobileJoystick = joystick;

        // выбор Input режима
        inputService = new MobileInput(mobileJoystick);
    }

    private IInputService InitInput()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            Debug.Log("Init mobile inputService");
            return new MobileInput(mobileJoystick);
        }

        Debug.Log("Init desktop inputService");
        return new KeyboardInput();
    }

    public void MoveByInput(Transform playerSprite)
    {
        var direction = inputService.GetAxis();
        unitMoveable.Move(direction);

        if (direction.x > 0)
        {
            playerSprite.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (direction.x < 0)
        {
            playerSprite.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
using UnityEngine;

public class UnitPlayerController : MonoBehaviour
{
    private UnitPlayerMovement playerMovement;
    public Joystick mobileJoystick;
    public Transform sprite;

    public void Init()
    {
        playerMovement = new UnitPlayerMovement(GetComponent<IMovable>(), mobileJoystick);
    }

    private void FixedUpdate()
    {
        playerMovement.MoveByInput(sprite);
    }
}
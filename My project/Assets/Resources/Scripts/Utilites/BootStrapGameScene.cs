using UnityEngine;

public class BootStrapGameScene : MonoBehaviour
{
    [SerializeField] private GameObject mobileUI;
    [SerializeField] private UnitPlayer player;
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private UiManager uiManager;

    [SerializeField] private Spawner spawner;

    private void Awake()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
            mobileUI.SetActive(true);

        uiManager.Init();

        player.Init();

        cameraFollow.Init(player.transform);

        spawner.Init();
    }
}
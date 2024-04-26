using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIEvents
{
    public static Action disableWeaponUI;
    public static Action<bool> toggleWeaponPanel, toggleLosePanel;
    public static Action<float> onHealthChanged;
    public static Action<float> setBasicHealthUISetUp;
    public static Action<int, bool> onBulletsChanged;
}

public class UiManager : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] private TMP_Text reloadUI;
    [SerializeField] private TMP_Text bulletsUI;
    [SerializeField] private Button shootButton;

    [Header("Health")]
    [SerializeField] private Slider healthSlider;

    [Header("Lose")]
    [SerializeField] private GameObject losePanel;

    public void Init()
    {

    }

    private void OnEnable()
    {
        UIEvents.toggleWeaponPanel += EnableDisableWeaponDisplay;
        UIEvents.toggleLosePanel += EnableDisableLosePanel;
        UIEvents.setBasicHealthUISetUp += HealthSetUp;
        UIEvents.onHealthChanged += UpdateHealthUI;
        UIEvents.disableWeaponUI += DisableWeaponUI;
        UIEvents.onBulletsChanged += UpdateBulletsUI;
    }

    private void HealthSetUp(float maxHealth)
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = maxHealth;
        }
    }

    private void UpdateHealthUI(float health)
    {
        if (healthSlider != null)
            healthSlider.value = health;
    }

    private void UpdateBulletsUI(int oneMagAmountBullets, bool activeReloadText)
    {
        bulletsUI.text = oneMagAmountBullets.ToString();
        reloadUI.gameObject.SetActive(activeReloadText);
    }

    private void DisableWeaponUI()
    {
        reloadUI.gameObject.SetActive(false);
    }

    private void EnableDisableWeaponDisplay(bool toggleWeaponDisplay)
    {
        shootButton.gameObject.SetActive(toggleWeaponDisplay);
        bulletsUI.gameObject.SetActive(toggleWeaponDisplay);

    }

    private void EnableDisableLosePanel(bool toggleLosePanel)
    {
        losePanel.gameObject.SetActive(toggleLosePanel);
    }

    private void OnDisable()
    {
        UIEvents.toggleWeaponPanel = null;
        UIEvents.toggleLosePanel = null;
        UIEvents.setBasicHealthUISetUp = null;
        UIEvents.onHealthChanged = null;
        UIEvents.onBulletsChanged = null;
        UIEvents.disableWeaponUI = null;
        UIEvents.onBulletsChanged = null;
    }
}
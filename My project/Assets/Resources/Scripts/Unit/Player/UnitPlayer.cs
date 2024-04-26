using Unity;
using UnityEngine;

public class UnitPlayer : Unit
{
    [HideInInspector] public UnitPlayerController unitPlayerController;
    [HideInInspector] public UnitMovableRigidbody unitMovableRigidbody;

    [HideInInspector] public UnitPlayerHealth unitHealthScript;
    [HideInInspector] public UnitPlayerWeaponController weaponController;

    [HideInInspector] public InventoryControllerView inventoryController;

    public void Init()
    {
        unitMovableRigidbody = GetComponent<UnitMovableRigidbody>();
        unitPlayerController = GetComponent<UnitPlayerController>();
        inventoryController = GetComponent<InventoryControllerView>();
        weaponController = GetComponent<UnitPlayerWeaponController>();
        unitHealthScript = GetComponent<UnitPlayerHealth>();

        if (unitMovableRigidbody != null)
            unitMovableRigidbody.Init();

        if (unitPlayerController != null)
            unitPlayerController.Init();

        if (inventoryController != null)
            inventoryController.Init();

        if (weaponController != null)
            weaponController.Init();

        if(unitHealthScript != null)
            unitHealthScript.Init();
    }
}
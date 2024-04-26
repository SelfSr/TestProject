using UnityEngine;

public class WeaponItem : Item, IUsable, IDestroyable
{
    public GameObject weapon;
    public void Use()
    {
        EventsManager.deleteItem?.Invoke(weapon);
        UIEvents.toggleWeaponPanel?.Invoke(true);
        EventsManager.setWeapon?.Invoke(weapon);
    }

    public void DestroyItem()
    {
        EventsManager.deleteItem?.Invoke(weapon);
    }
}
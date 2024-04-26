using UnityEngine;

public class AmmoItem : Item, IUsable
{
    public void Use()
    {
        Amount--;
        InventoryEvents.OnInventoryChanged();
        if (Amount <= 0)
            InventoryEvents.OnInventoryDeleteItem(this);
    }
}
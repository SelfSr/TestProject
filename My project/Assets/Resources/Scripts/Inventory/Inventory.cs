using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryEvents
{
    public static event Action InventoryChanged;
    public static event Action<Item> InventoryDeleteItem;
    public static event Action<Item> InventoryUseItem;

    public static void OnInventoryChanged()
    {
        InventoryChanged?.Invoke();
    }

    public static void OnInventoryDeleteItem(Item item)
    {
        InventoryDeleteItem?.Invoke(item);
    }

    public static void OnInventoryUseItem(Item item)
    {
        InventoryUseItem?.Invoke(item);
    }
}

[Serializable]
public class Inventory
{
    private List<Item> items;
    private int maxInventorySize;

    public Inventory(int InventorySize)
    {
        SetInventoryMaxSize(InventorySize);
        maxInventorySize = InventorySize;

        InventoryEvents.InventoryDeleteItem += RemoveItem;
        InventoryEvents.InventoryUseItem += UseItem;
    }

    public void SetInventoryMaxSize(int InventorySize)
    {
        items = new List<Item>(InventorySize);
    }

    public void AddItem(Item newItem)
    {
        int maxStack = ItemTypeManager.Instance.GetMaxStackForType(newItem.ItemType);
        if (CheckInventoryFull())
            return;

        if (maxStack == 1 && newItem.Amount > maxStack)
            newItem.Amount = maxStack;

        foreach (Item item in items)
        {
            if (item.ItemType == newItem.ItemType)
            {
                int remainingSpace = maxStack - item.Amount;
                if (remainingSpace > 0)
                {
                    int amountToAdd = Mathf.Min(newItem.Amount, remainingSpace);
                    item.Amount += amountToAdd;
                    newItem.Amount -= amountToAdd;

                    if (newItem.Amount == 0)
                    {
                        InventoryEvents.OnInventoryChanged();
                        return;
                    }
                }
            }
        }

        if (newItem.Amount > 0)
        {
            items.Add(newItem);
            InventoryEvents.OnInventoryChanged();
        }
    }

    public bool CheckInventoryFull()
    {
        int inventorySize = items.Count;
        return inventorySize >= maxInventorySize;
    }

    public void RemoveItem(Item itemToRemove)
    {
        items.Remove(itemToRemove);
        InventoryEvents.OnInventoryChanged();
        UIEvents.toggleWeaponPanel?.Invoke(false);

        var item = itemToRemove.GetComponent<IDestroyable>();
        if (item != null)
        {
            item.DestroyItem();
        }
    }

    public void UseItem(Item itemToUse)
    {
        var item = itemToUse.GetComponent<IUsable>();
        if(item != null)
        {
            item.Use();
            InventoryEvents.OnInventoryChanged();
        }
    }

    public List<Item> GetItems()
    {
        return items;
    }
}
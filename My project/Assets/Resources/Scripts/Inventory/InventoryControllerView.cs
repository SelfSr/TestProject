using System.Collections.Generic;
using UnityEngine;

public class InventoryControllerView : MonoBehaviour
{
    [HideInInspector] public Inventory inventory;
    public int inventorySize;
    public Transform InventoryPanel;
    public GameObject inventorySlotPrefab;

    private Dictionary<Item, InventorySlotView> itemToSlotMap = new ();

    private ISaveSystem saveSystem;

    private SaveData data;

    public void Init()
    {
        inventory = new Inventory(inventorySize);

        saveSystem = new JsonSaveSystem();
        data = saveSystem.Load();

        if (data != null && data.items != null)
        {
            foreach (var item in data.items)
            {
                inventory.AddItem(item);
            }
        }

        UpdateInventoryDisplay();

        InventoryEvents.InventoryChanged += UpdateInventoryDisplay;
    }

    public void UpdateInventoryDisplay()
    {
        List<Item> items = inventory.GetItems();

        foreach (Item item in items)
        {
            if (itemToSlotMap.ContainsKey(item))
            {
                itemToSlotMap[item].UpdateItemInfo(item);
            }
            else
            {
                GameObject slot = Instantiate(inventorySlotPrefab, InventoryPanel);
                InventorySlotView slotScript = slot.GetComponent<InventorySlotView>();
                slotScript.UpdateItemInfo(item);
                itemToSlotMap.Add(item, slotScript);
            }
        }

        List<Item> itemsToRemove = new List<Item>(itemToSlotMap.Keys);
        foreach (Item item in itemsToRemove)
        {
            if (!items.Contains(item))
            {
                Destroy(itemToSlotMap[item].gameObject);
                itemToSlotMap.Remove(item);
            }
        }
    }

    private void OnDestroy()
    {
       InventoryEvents.InventoryChanged -= UpdateInventoryDisplay;
    }

    public void Save()
    {
        data.items = inventory.GetItems();
        saveSystem.Save(data);
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}
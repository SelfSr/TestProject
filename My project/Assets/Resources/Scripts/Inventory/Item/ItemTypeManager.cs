using System.Collections.Generic;

public class ItemTypeManager
{
    private static ItemTypeManager instance;
    public static ItemTypeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ItemTypeManager();
            }
            return instance;
        }
    }

    public List<ItemTypeInfo> itemTypes = new List<ItemTypeInfo>();

    public ItemTypeManager()
    {
        SetDefaultItemTypes();
    }

    private void SetDefaultItemTypes()
    {
        SetMaxStackForType(ItemType.Weapon, 1);
        SetMaxStackForType(ItemType.Ammo, 99);
        //....
    }

    public void SetMaxStackForType(ItemType type, int maxStack)
    {
        itemTypes.Add(new ItemTypeInfo(type, maxStack));
    }

    public int GetMaxStackForType(ItemType type)
    {
        foreach (ItemTypeInfo info in itemTypes)
        {
            if (info.Type == type)
            {
                return info.MaxStack;
            }
        }
        return 1;
    }
}

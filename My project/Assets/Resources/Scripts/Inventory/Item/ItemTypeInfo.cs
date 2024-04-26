[System.Serializable]
public class ItemTypeInfo
{
    public ItemType Type;
    public int MaxStack;

    public ItemTypeInfo(ItemType type, int maxStack)
    {
        Type = type;
        MaxStack = maxStack;
    }
}
using UnityEngine;

[System.Serializable]
public enum ItemType
{
    Weapon,
    Ammo
}

[System.Serializable]
public abstract class Item : MonoBehaviour
{
    public ItemType ItemType;
    public int Amount = 1;
    public string ItemName;
    public Sprite Icon;
    public Color BackgroundColor;
}
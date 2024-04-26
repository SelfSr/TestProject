using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotView : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text amountText;
    public Image iconImage;
    public Image background;

    private Item item;
    public void UpdateItemInfo(Item updatedItem)
    {
        item = updatedItem;

        nameText.text = updatedItem.ItemName;
        amountText.text = updatedItem.Amount > 1 ? updatedItem.Amount.ToString() : "";

        if (updatedItem.Icon != null)
        {
            iconImage.sprite = updatedItem.Icon;
            iconImage.enabled = true;
        }
        else
        {
            iconImage.enabled = false;
        }

        background.color = updatedItem.BackgroundColor;
    }
    public void DeleteButton()
    {
        InventoryEvents.OnInventoryDeleteItem(item);
        UpdateItemInfo(item);
    }

    public void UseButton()
    {
        InventoryEvents.OnInventoryUseItem(item);
        UpdateItemInfo(item);
    }
}
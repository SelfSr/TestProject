using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class ItemPickUp : MonoBehaviour
{
    [SerializeField] private Item itemToAdd;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickupItem(collision);
        }
    }

    private void PickupItem(Collider2D col)
    {
        Inventory playerInventory = col.GetComponent<InventoryControllerView>().inventory;

        if (playerInventory != null)
        {
            if (playerInventory.CheckInventoryFull())
                return;

            playerInventory.AddItem(itemToAdd);
            gameObject.SetActive(false);
        }
    }
}
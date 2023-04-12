using UnityEngine;

[System.Serializable]
public class Inventory 
{
    public InventorySlot[] slots;

    public Inventory(int size)
    {
        slots = new InventorySlot[size];
        for (int i = 0; i < size; i++)
        {
            slots[i] = new InventorySlot(null, 0);
        }
    }

    public void AddSlots(int added)
    {
        InventorySlot[] newSlots = new InventorySlot[slots.Length + added];
        for (int i = 0; i < newSlots.Length; i++)
        {
            if (i < slots.Length) newSlots[i] = slots[i];
            else newSlots[i] = new InventorySlot(null, 0);
        }
        slots = newSlots;
    }

    public void AddItemToRandomPos(InventorySlot slot)
    {
        bool canAddItem = false;
        for (int i = 0; i < slots.Length; i++)
        {
            if (CanAddItem(slots[i], slot))
            {
                canAddItem = true;
                break;
            }
        }

        if (!canAddItem)
        {
            Debug.LogWarning("Can't add item. There is no more space for it");
            return;
        }

        while (true)
        {
            int id = Random.Range(0, slots.Length);
            if (CanAddItem(slots[id], slot))
            {
                if (slots[id].item == null) slots[id] = slot;
                else slots[id].AddItems(slot.amount);
                break;
            }
        }
    }

    private bool CanAddItem(InventorySlot slot, InventorySlot addingSlot)
    {
        if (slot.item == null) return true;
        if (slot.item == addingSlot.item)
        {
            if (slot.item.maxInStack >= slot.amount + addingSlot.amount) return true;
        }
        return false;
    }
}
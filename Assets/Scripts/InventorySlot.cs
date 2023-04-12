using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    [field: SerializeField] public Item item { get; private set; }
    [field: SerializeField] public int amount { get; private set; }

    public InventorySlot(Item item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }

    public bool AddItems(int amount)
    {
        if (this.amount + amount <= item.maxInStack)
        {
            this.amount += amount;
            return true;
        }
        else return false;
    }

    public bool RemoveItems(int amount)
    {
        if (this.amount - amount >= 0)
        {
            this.amount -= amount;
            if (this.amount <= 0) ClearSlot();
            return true;
        }
        else return false;
    }

    public void ClearSlot()
    {
        item = null;
        amount = 0;
    }
}
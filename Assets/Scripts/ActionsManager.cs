using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ActionsManager : MonoBehaviour
{
    public void Shoot()
    {
        var inventory = Player.instance.inventory;

        List<InventorySlot> possibleForShootAmmos = new List<InventorySlot>();

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item is Ammo && inventory.slots[i].amount > 0) possibleForShootAmmos.Add(inventory.slots[i]);
        }

        if (possibleForShootAmmos.Count == 0)
        {
            Debug.LogWarning("There is no ammo to shoot");
            return;
        }
        else
        {
            int id = Random.Range(0, possibleForShootAmmos.Count);
            Debug.Log(string.Format("Shooted {0} bullet", possibleForShootAmmos[id].item.name));
            possibleForShootAmmos[id].RemoveItems(1);
        }
    }

    public void AddAmmo()
    {
        var inventory = Player.instance.inventory;

        List<Ammo> ammos = new List<Ammo>();

        for (int i = 0; i < Items.instance.items.Length; i++)
        {
            if (Items.instance.items[i] is Ammo) ammos.Add(Items.instance.items[i] as Ammo);
        }

        for (int i = 0; i < ammos.Count; i++)
        {
            inventory.AddItemToRandomPos(new InventorySlot(ammos[i], ammos[i].maxInStack));
        }
    }

    public void AddItem()
    {
        var inventory = Player.instance.inventory;

        // Get all assemblies loaded in the current application domain
        var assemblies = System.AppDomain.CurrentDomain.GetAssemblies();

        // Get all types that derive from MyBaseClass
        var derivedTypes = assemblies
            .SelectMany(s => s.GetTypes())
            .Where(p => typeof(Item).IsAssignableFrom(p) && !p.IsAbstract);

        // Loop through each derived type and do something
        foreach (var type in derivedTypes)
        {
            for (int i = 0; i < 50; i++)
            {
                int itemIndex = Random.Range(0, Items.instance.items.Length);
                Item item = Items.instance.items[itemIndex];
                if (type.IsAssignableFrom(item.GetType()))
                {
                    inventory.AddItemToRandomPos(new InventorySlot(item, 1));
                    break;
                }
            }
        }
    }

    public void RemoveItem()
    {
        var inventory = Player.instance.inventory;
        bool haveItems = false;
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].amount > 0)
            {
                haveItems = true;
                break;
            }
        }
        if (!haveItems)
        {
            Debug.LogWarning("There is no items to delete");
            return;
        }

        while (true)
        {
            int itemIndex = Random.Range(0, inventory.slots.Length);
            if (inventory.slots[itemIndex].amount > 0)
            {
                Debug.Log(string.Format("Item {0} removed", inventory.slots[itemIndex].item.name));
                inventory.slots[itemIndex].ClearSlot();
                return;
            }
        }
    }
}
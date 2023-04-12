using UnityEngine;

public class InventoryManagerUI : MonoBehaviour
{
    public static InventoryManagerUI instance;
    [SerializeField] private ItemPanel[] panels; // It would be possible to spawn them during Start or UpdateInfo, but I decided to just throw them through the inspector

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
    }

    public void UpdateInfo(Inventory inventory)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (i < inventory.slots.Length ) panels[i].UpdateInfo(inventory.slots[i]);
            else panels[i].ShowAsLocked();
        }
    }

    public void UpdateInfo()
    {
        UpdateInfo(Player.instance.inventory);
    }
}
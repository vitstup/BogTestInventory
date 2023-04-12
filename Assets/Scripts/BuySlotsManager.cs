using UnityEngine;

public class BuySlotsManager : MonoBehaviour
{
    [SerializeField] private int slotsToBuy = 15;
    [SerializeField] private int price = 1000;

    public void BuySlots()
    {
        Player.instance.inventory.AddSlots(slotsToBuy);

        // take money from player

        InventoryManagerUI.instance.UpdateInfo();
    }
}
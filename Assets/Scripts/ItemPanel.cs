using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemPanel : MonoBehaviour
{
    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI itemAmountText;

    public void UpdateInfo(InventorySlot slot)
    {
        if (slot.item == null)
        {
            itemSprite.gameObject.SetActive(false);
            itemAmountText.gameObject.SetActive(false);
        }
        else
        {
            itemSprite.gameObject.SetActive(true);
            itemSprite.sprite = slot.item.sprite;

            if (slot.amount > 1)
            {
                itemAmountText.gameObject.SetActive(true);
                itemAmountText.text = slot.amount.ToString();
            }
            else itemAmountText.gameObject.SetActive(false);
        }
    }

    public void ShowAsLocked()
    {
        itemSprite.gameObject.SetActive(true);
        itemAmountText.gameObject.SetActive(false);
    }
}
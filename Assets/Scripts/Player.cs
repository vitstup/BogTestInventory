using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [HideInInspector] public Inventory inventory;

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        inventory = new Inventory(15);

        InventoryManagerUI.instance.UpdateInfo(inventory);
    }
}
using UnityEngine;

public class Items : MonoBehaviour
{
    public static Items instance;

    public Item[] items; // all items in the project. It would be possible to load them from resorces

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
    }
}
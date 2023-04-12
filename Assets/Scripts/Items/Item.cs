using UnityEngine;

public abstract class Item : ScriptableObject
{
    [field: SerializeField] public Sprite sprite { get; private set; }
    [field: SerializeField] public int maxInStack { get; private set; }
    [field: SerializeField] public float weight { get; private set; } 

}
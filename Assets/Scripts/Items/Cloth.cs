using UnityEngine;

public abstract class Cloth : Item
{
    [field: SerializeField] public int protection { get; private set; }
}
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{
    [field: SerializeField] public Ammo usingAmmo { get; private set; }
    [field: SerializeField] public int damage { get; private set; }
}
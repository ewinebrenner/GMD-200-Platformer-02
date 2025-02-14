using UnityEngine;

[CreateAssetMenu(menuName = "Platformer/Item")]
public class Item : ScriptableObject
{
    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Legendary
    }
    public enum ItemType
    {
        Weapon,
        Food
    }
    public string name;
    public Rarity rarity;
    public ItemType type;
    public int value;
    public float damage;
    public float healAmount;
}
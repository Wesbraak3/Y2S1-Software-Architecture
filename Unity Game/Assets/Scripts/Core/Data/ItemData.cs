using UnityEngine;

namespace Core.Data
{
    public enum ItemType { Weapon, Armor, Consumable, Material }
    public enum Rarity { Common, Uncommon, Rare, Legendary }
    public enum DamageTypes { Physical, Magical, Elemental }
    
    [CreateAssetMenu(fileName = "ItemDate", menuName = "Scriptable Objects/CreateNewItemData")]
    public class ItemData : ScriptableObject
    {
        [Header("Item Unique ID")]
        public int id;
        
        [Header("Item Data")]
        public string itemName;
        public string description;
        public int rarity;

        public ItemType itemType;
        public int maxStack = 1;

        [Header("Item Visuals")]
        public Sprite itemIcon;
        public GameObject itemPrefab;
        
        [Header("Item Stats")]
        [Header("Weapon Stats")]
        public int damage;
        
        [Header("Armor Stats")]
        public int armor;
        public int magicResist;
        
        [Header("Item Requirements")]
        public int strength;
        public int dexterity;
        public int intelligence;
        public int wisdom;

        public Item CreateItem() => new Item(this);
    }

    public class Item
    {
        [Header("Item Unique ID")]
        public int id;
        
        [Header("Item Data")]
        public string itemName;
        public string description;
        public int rarity;
        
        [Header("Item Visuals")]
        public Sprite itemIcon;
        public GameObject itemPrefab;
        
        [Header("Item Stats")]
        [Header("Weapon Stats")]
        public int damage;
        
        [Header("Armor Stats")]
        public int armor;
        public int magicResist;
        
        [Header("Item Requirements")]
        public int strength;
        public int dexterity;
        public int intelligence;
        public int wisdom;
        
        public Item(ItemData itemData)
        {
        }
    }
}
using System;
using UnityEngine;

namespace Inventory
{
    public enum ItemType { Weapon, Armor, Consumable, Material }
    public enum Rarity { Common, Uncommon, Rare, Legendary }
    public enum DamageTypes { Physical, Elemental }
    
    [CreateAssetMenu(fileName = "ItemDate", menuName = "Scriptable Objects/CreateNewItemData")]
    public class ItemData : ScriptableObject
    {
        [Header("Item Unique ID")]
        public Guid id = Guid.NewGuid();
        
        [Header("Item Data")]
        public string itemName;
        public string description;

        [Header("Item Visuals")]
        public Sprite itemIcon;
        public GameObject itemPrefab;
        public Item CreateItem() => new (this);
    }

    public class Item
    {
        [Header("Item Unique ID")]
        private Guid id;

        [Header("Item Data")]
        public string itemName;
        public string description;

        [Header("Item Visuals")]
        public Sprite itemIcon;
        public GameObject itemPrefab;

        public Item(ItemData itemData)
        {
        }
    }
}
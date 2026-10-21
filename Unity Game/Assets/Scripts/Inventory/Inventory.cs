using System.Collections.Generic;
using UnityEngine;

namespace Inventory {
    public class Inventory : MonoBehaviour {

        [SerializeField] private List<Item> _items = new();

        public ItemData itemData;


        [ContextMenuItem("naem")]
        public void AddItem() {
            _items.Add(itemData.CreateItem());
        }
    }
}
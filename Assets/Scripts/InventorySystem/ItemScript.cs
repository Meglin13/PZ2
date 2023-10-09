using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.Items
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class ItemScript : MonoBehaviour
    {
        [SerializeField]
        private List<Item> Items = new List<Item>();

        [SerializeField]
        private Item item;
        public Item Item => item;

        [SerializeField]
        private SpriteRenderer icon;

        private void OnEnable()
        {
            item = Items[Random.Range(0, Items.Count)];
            icon.sprite = item.Icon;
        }
    }
}
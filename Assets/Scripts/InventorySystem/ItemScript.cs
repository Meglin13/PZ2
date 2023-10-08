using InventorySystem;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class ItemScript : MonoBehaviour
    {
        [SerializeField]
        private List<Item> Items = new List<Item>();

        [SerializeField]
        private Item item;

        [SerializeField]
        private SpriteRenderer icon;

        private void OnEnable()
        {
            item = Items[Random.Range(0, Items.Count)];
            icon.sprite = item.Icon;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Got item!");
                //TODO: Поднятие предмета
                //item.OnPickUp();
            }
        }
    }
}
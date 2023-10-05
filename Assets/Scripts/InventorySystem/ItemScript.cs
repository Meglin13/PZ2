using InventorySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Inventory
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class ItemScript : MonoBehaviour
    {
        [SerializeField]
        private Item item;

        //TODO: Поднятие предмета
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("Got item!");
                item.OnPickUp();
            }
        }
    }
}

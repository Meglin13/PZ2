using Entities.Player;
using InventorySystem.Items;
using UnityEngine;

namespace InventorySystem.Inventory
{
    public class InventoryPlayerMediator : MonoBehaviour
    {
        [SerializeField]
        private PlayerPresenter player;
        [SerializeField]
        private InventoryPresenter inventory;

        private void Awake()
        {
            player.SetInventoryMediator(this);
            inventory.SetInventoryMediator(this);
        }

        public void PlayerPickedUpItem(Item item)
        {
            inventory.Model.AddItem(item);
        }

        public void PlayerUsedItem(Item item)
        {
            item.UseItem(player.Model);
            inventory.Model.RemoveItem(item);
        }
    }
}

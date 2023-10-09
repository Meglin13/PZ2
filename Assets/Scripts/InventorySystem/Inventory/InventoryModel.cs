using InventorySystem.Items;
using MVP.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InventorySystem.Inventory
{
    [Serializable]
    public class InventoryModel : BaseModel<InventoryPresenter>
    {
        [SerializeField]
        private int capacity;

        public int Capacity => capacity;

        [SerializeField]
        private List<Item> inventory = new List<Item>();

        public List<Item> Inventory
        {
            get
            {
                inventory = inventory.Where(item => item != null).ToList();
                inventory.Capacity = Capacity;

                return inventory;
            }
        }

        public event Action OnInventoryChanged = delegate { };

        //TODO: Сохранение и загрузка инвентаря
        public override void OnInit()
        {
            
        }

        public void AddItem(Item Item)
        {
            if (Inventory.Count < Inventory.Capacity)
            {
                if (Inventory.Where(x => x.ID == Item.ID).FirstOrDefault())
                {
                    Inventory[Inventory.IndexOf(Inventory.Where(x => x.Name == Item.Name).FirstOrDefault())].Amount += 1;
                }
                else
                {
                    Item NewItem = Item.InstanceID == string.Empty ? Item.GetCopy() : Item;

                    Inventory.Add(NewItem);
                }

                OnInventoryChanged();
            }
        }

        public void RemoveItem(Item item)
        {
            Item ItemForDelete = Inventory.Where(x => x.InstanceID == item.InstanceID).First();

            if (ItemForDelete.Amount > 1)
            {
                ItemForDelete.Amount--;
            }
            else
            {
                Inventory.Remove(ItemForDelete);
            }

            OnInventoryChanged();
        }
    }
}
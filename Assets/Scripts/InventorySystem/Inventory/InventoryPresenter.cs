using InventorySystem.Items;
using MVP.Base;
using SaveLoadSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InventorySystem.Inventory
{
    public class InventoryPresenter : BasePresenter<InventoryView, InventoryModel>, ISaveable
    {
        private InventoryPlayerMediator mediator;

        public override void Init(InventoryView view, InventoryModel model)
        {
            base.Init(view, model);

            model.OnInventoryChanged += () => view.UpdateView();
        }

        public void SetInventoryMediator(InventoryPlayerMediator mediator)
        {
            this.mediator = mediator;
        }

        public void UseItem(Item item)
        {
            mediator.PlayerUsedItem(item);
        }

        public object GetObjects()
        {
            var list = new List<InventoryItem>();

            foreach (var item in model.Inventory)
            {
                var data = new InventoryItem()
                {
                    ID = item.ID,
                    amount = item.Amount
                };

                list.Add(data);
            }

            return list;
        }

        //TODO: Загрузка предметов инвентаря
        public void LoadObjects(object save)
        {
            var resources = Resources.LoadAll<Item>(@"SO\Items");

            foreach (var item in (List<InventoryItem>)save)
            {
                var savedItem = resources.Where(x => x.ID == item.ID).FirstOrDefault();
                savedItem.Amount = item.amount;

                model.AddItem(savedItem);
            }
        }

        [Serializable]
        private struct InventoryItem
        {
            public string ID;
            public int amount;
        }
    }
}
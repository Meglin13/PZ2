using InventorySystem.Items;
using MVP.Base;
using SaveLoadSystem;
using System.Collections.Generic;

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
            return model.Inventory;
        }

        public void LoadObjects(object save)
        {
            model.LoadInventory((List<Item>)save);
        }
    }
}
using InventorySystem.Items;
using MVP.Base;

namespace InventorySystem.Inventory
{
    public class InventoryPresenter : BasePresenter<InventoryView, InventoryModel>
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
    }
}
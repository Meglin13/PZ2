using Entities.Player;
using MVP.Base;
using UnityEngine;

namespace InventorySystem.Inventory
{
    public class InventoryPresenter : BasePresenter<InventoryView, InventoryModel>
    {
        [SerializeField]
        private PlayerPresenter playerPresenter;

        public PlayerPresenter PlayerPresenter => playerPresenter;

        public override void Init(InventoryView view, InventoryModel model)
        {
            base.Init(view, model);

            model.OnInventoryChanged += () => view.UpdateView();
        }
    }
}
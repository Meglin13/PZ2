using MVP.Base;
using MVP.Base.Interfaces;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;

namespace InventorySystem.Inventory
{
    public class InventoryView : BaseView<InventoryPresenter>
    {
        private InventoryModel inventory;

        [SerializeField]
        private GameObject InventoryContainer;

        private List<InventorySlot> InventorySlots = new List<InventorySlot>();
        private Item itemContext;

        [SerializeField]
        private InventorySlot slotPrefab;

        [SerializeField]
        private TextMeshProUGUI itemNameText;
        [SerializeField]
        private TextMeshProUGUI itemDescText;

        public override void OnInit(IPresenter presenter)
        {
            base.OnInit(presenter);

            inventory = Presenter.Model;

            for (int i = 0; i < Presenter.Model.Capacity; i++)
            {
                var slot = Instantiate(slotPrefab, InventoryContainer.transform);

                slot.name = $"Slot {i + 1}";

                InventorySlots.Add(slot);

                slot.Button.onClick.AddListener(() => SetInfoBox(slot.ItemContext));
            }

            UpdateView();
        }

        public override void UpdateView()
        {
            for (int i = 0; i < Presenter.Model.Capacity; i++)
            {
                if (inventory.Inventory.Count > i)
                {
                    InventorySlots[i].SetSlot(inventory.Inventory[i]);
                }
                else
                {
                    InventorySlots[i].SetSlot();
                }
            }

            SetInfoBox();
        }

        public void SetInfoBox(Item item = null)
        {
            if (item != null)
            {
                itemContext = item;

                itemNameText.text = item.Name;
                itemDescText.text = item.Desc;
            }
            else
            {
                itemContext = null;

                itemNameText.text = string.Empty;
                itemDescText.text = string.Empty;
            }
        }

        //TODO: Кнопки инвентаря
        public void DeleteItemButtonClicked()
        {
            if (itemContext != null)
            {
                inventory.RemoveItem(itemContext);
            }
        }

        public void UseItemButtonClicked()
        {
            if (itemContext != null)
            {
                itemContext.UseItem(Presenter.PlayerPresenter.Model);
            }
        }
    }
}
using Entities.Interfaces;
using Entities.Player;
using InventorySystem.Inventory;
using UnityEngine;

namespace InventorySystem.Items
{
    /// <summary>
    /// Класс предметов поддержки: здоровье, пули и другие предметы
    /// </summary>
    public class SupplyItem<T> : Item where T : IStat
    {
        [SerializeField]
        protected int supplyAmount;

        public int SupplyAmount => supplyAmount;

        public override void OnPickUp(InventoryModel inventory) { }

        public override void UseItem(PlayerModel model) => model.GetStat<T>().ChangeValue(supplyAmount);
    }
}
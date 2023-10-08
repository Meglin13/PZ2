using Entities;
using UnityEngine;

namespace InventorySystem.Items
{
    [CreateAssetMenu(fileName = "Health", menuName = "Items/Supply/Health")]
    public class HealthSupplyItem : SupplyItem<HealthStat>
    {
    }
}
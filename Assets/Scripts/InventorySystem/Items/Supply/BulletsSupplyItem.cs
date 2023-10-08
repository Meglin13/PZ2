using Entities;
using UnityEngine;

namespace InventorySystem.Items
{
    [CreateAssetMenu(fileName = "Bullets", menuName = "Items/Supply/Bullets")]
    public class BulletsSupplyItem : SupplyItem<BulletsStat>
    {
    }
}
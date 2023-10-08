using Akaal.PvCustomizer.Scripts;
using Entities.Player;
using InventorySystem.Inventory;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

namespace InventorySystem
{
    public abstract class Item : ScriptableObject
    {
        #region [Instances Managment]

#if UNITY_EDITOR
        public virtual void OnValidate()
        {
            id = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(this));
        }
#endif

        [ReadOnly]
        [SerializeField]
        private string id;
        public string ID => id;

        public string InstanceID;
        public static int lastID = 0;

        [SerializeField]
        private string _name;
        public string Name => _name;

        [SerializeField]
        private string desc;
        public string Desc => desc;

        private int amount = 1;
        public int Amount { get => amount; set => amount = value; }

        [SerializeField]
        private int stackCapacity = 999;
        public int StackCapacity => stackCapacity;

        [SerializeField]
        [PvIcon]
        private Sprite icon;
        public Sprite Icon => icon;


        public Item GetCopy()
        {
            var item = Instantiate(this);

            item.InstanceID = item.GetType().ToString()[0] + "_" + lastID;
            lastID++;

            return item;
        }

        #endregion

        //TODO: Добавление предмета в инвентарь
        public virtual void OnPickUp(InventoryModel inventory)
        {
            inventory.AddItem(this);
        }

        public abstract void UseItem(PlayerModel player);
    }
}

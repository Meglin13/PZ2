using Akaal.PvCustomizer.Scripts;
using System.IO;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

namespace InventorySystem
{
    //TODO: Предметы
    public abstract class Item : ScriptableObject
    {
        #region [Instances Managment]

#if UNITY_EDITOR
        public virtual void OnValidate()
        {
            id = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(this));

            string assetPath = AssetDatabase.GetAssetPath(this.GetInstanceID());
            this.itemName = Path.GetFileNameWithoutExtension(assetPath);
        }
#endif

        [ReadOnly]
        [SerializeField]
        private string id;
        public string ID => id;

        [ReadOnly]
        public string InstanceID;
        public static int lastID = 0;

        [SerializeField]
        [PvIcon]
        private string itemName;
        public string ItemName => itemName;


        [SerializeField]
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

        public abstract void OnPickUp();

        public abstract void UseItem();
    }
}

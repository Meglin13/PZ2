using InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Класс отвечающий за логику слота инвентаря
    /// </summary>
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField]
        private Image icon;

        [SerializeField]
        private TextMeshProUGUI itemAmount;

        private Item itemContext;
        public Item ItemContext => itemContext;

        [SerializeField]
        private Button button;

        public Button Button => button;

        public void SetSlot(Item item = null)
        {
            if (item != null)
            {
                icon.enabled = true;
                Button.enabled = true;
                icon.sprite = item.Icon;

                if (item.Amount > 1)
                {
                    itemAmount.text = item.Amount.ToString();
                }
                else
                {
                    itemAmount.text = string.Empty;
                }
            }
            else
            {
                icon.enabled = false;
                itemAmount.text = string.Empty;
                Button.enabled = false;
            }
        }
    }
}
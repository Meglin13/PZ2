using Entities.Interfaces;
using System;
using UnityEngine;

namespace Entities
{
    public class HealthStat : IStat
    {
        private int value;

        public int CurrentValue
        {
            get => value;
            set
            {
                this.value = Mathf.Clamp(this.value, 0, value);

                OnValueChanged();

                if (this.value == 0)
                {
                    OnValueEmpty();
                }
            }
        }

        public event Action OnValueChanged = delegate { };

        public event Action OnValueEmpty = delegate { };

        public void ChangeValue(int amount)
        {
            value += amount;
        }

        public void ClearEvents()
        {
            OnValueChanged = null;
            OnValueEmpty = null;
        }
    }
}
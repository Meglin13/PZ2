using Entities.Interfaces;
using System;
using UnityEngine;

namespace Entities
{
    [Serializable]
    public class HealthStat : IStat
    {
        private int MaxValue;

        [SerializeField]
        private int currentValue;

        public int CurrentValue
        {
            get => currentValue;
            set
            {
                currentValue = Mathf.Clamp(value, 0, MaxValue);

                OnValueChanged?.Invoke();

                if (currentValue == 0)
                {
                    OnValueEmpty?.Invoke();
                }
            }
        }

        public event Action OnValueChanged = delegate { };
        public event Action OnValueEmpty = delegate { };

        public HealthStat(int max) => MaxValue = max;

        public void ChangeValue(int amount)
        {
            CurrentValue += amount;
            OnValueChanged?.Invoke();
        }

        public void ClearEvents()
        {
            OnValueChanged = null;
            OnValueEmpty = null;
        }
    }
}
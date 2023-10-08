using System;

namespace Entities.Interfaces
{
    public interface IStat
    {
        public int CurrentValue { get; }

        public void ChangeValue(int amount);

        public event Action OnValueChanged;

        public event Action OnValueEmpty;

        public void ClearEvents();
    }
}
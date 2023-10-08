﻿using Entities.Interfaces;
using System;

namespace Entities
{
    public class BulletsStat : IStat
    {
        private int value;
        public int CurrentValue => value;

        private int availableBullets;

        public int AvailableBullets
        {
            get => availableBullets;
            set => availableBullets = value;
        }

        private int weaponBulletsAmount;

        public event Action OnValueChanged = delegate { };
        public event Action OnValueEmpty = delegate { };

        public BulletsStat()
        {
        }

        public void ClearEvents()
        {
            OnValueChanged = null;
            OnValueEmpty = null;
        }

        public void SetWeapoBulletsAmount(int amount) => weaponBulletsAmount = amount;

        /// <summary>
        /// Изменение количества пуль на -1
        /// </summary>
        public void ChangeValue()
        {
            value--;

            if (CurrentValue == 0)
            {
                Reload();
            }

            OnValueChanged();
        }

        /// <summary>
        /// Изменение количества пуль на заданное количество
        /// </summary>
        /// <param name="amount">Количество пуль</param>
        public void ChangeValue(int amount)
        {
            availableBullets += amount;
            OnValueChanged();
        }

        /// <summary>
        /// Перезарядка оружия
        /// </summary>
        public void Reload()
        {
            availableBullets += value;
            value = 0;

            if (AvailableBullets > 0)
            {
                int bulletsReload = AvailableBullets > weaponBulletsAmount ?
                    weaponBulletsAmount :
                    AvailableBullets;

                AvailableBullets -= bulletsReload;
                value = bulletsReload;
                OnValueChanged();
            }
        }
    }
}
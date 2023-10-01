using System;
using System.Collections.Generic;

namespace Player
{
    public class PlayerModel : EntityModel
    {
        #region Weapons

        private WeaponStats currentWeapon;
        public WeaponStats CurrentWeapon => currentWeapon;
        private List<WeaponStats> Weapons;

        private float currentBullets;
        public float CurrentBullets
        {
            get => currentBullets;
            set => currentBullets = value;
        }

        private float availableBullets;
        public float AvailableBullets
        {
            get => availableBullets;
            set => availableBullets = value;
        }

        public event Action OnBulletsChanged = delegate { };
        public event Action OnWeaponChanged = delegate { };

        #endregion

        public PlayerModel() : base()
        {
            
        }

        public PlayerModel(Stats stats, List<WeaponStats> weapons) : base(stats)
        {
            Weapons = weapons;
        }

        //TODO: Стрельба
        /// <summary>
        /// Изменение количества пуль на -1
        /// </summary>
        public void ChangeBullets()
        {
            CurrentBullets--;
            OnBulletsChanged();
        }

        /// <summary>
        /// Изменение количества пуль на заданное количество
        /// </summary>
        /// <param name="amount"></param>
        public void ChangeBullets(int amount)
        {
            CurrentBullets += amount;
            OnBulletsChanged();
        }

        //TODO: Смена оружия
        public void NextWeapon()
        {
            if (Weapons != null && CurrentWeapon != null)
            {
                var weaponIndex = Weapons.IndexOf(CurrentWeapon);
                weaponIndex = weaponIndex + 1 > Weapons.Count - 1 ? weaponIndex + 1 : 0;

                currentWeapon = Weapons[weaponIndex];
            }
        }

        /// <summary>
        /// Перезарядка оружия
        /// </summary>
        public void Reload()
        {
            if (AvailableBullets > 0)
            {
                var bulletsReload = AvailableBullets > CurrentWeapon.BulletsAmount ?
                    CurrentWeapon.BulletsAmount :
                    AvailableBullets;

                AvailableBullets -= bulletsReload;
                CurrentBullets = bulletsReload;
                OnBulletsChanged();
            }
        }

        public void SetWeapons(List<WeaponStats> weapons)
        {
            Weapons = weapons;
            currentWeapon = Weapons[0];
        }
    }
}
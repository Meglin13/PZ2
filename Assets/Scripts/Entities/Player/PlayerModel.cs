using Entities.BaseStats;
using System;
using System.Collections.Generic;

namespace Entities.Player
{
    [Serializable]
    public class PlayerModel : EntityModel
    {
        #region Weapons

        private WeaponStats currentWeapon;
        public WeaponStats CurrentWeapon => currentWeapon;

        private List<WeaponStats> Weapons;

        private BulletsStat bullets = new BulletsStat();
        public BulletsStat Bullets => bullets;

        public event Action OnWeaponChanged = delegate { };

        #endregion Weapons

        public override void OnInit()
        {
            base.OnInit();
            statsList.Add(Bullets);
        }

        public void NextWeapon()
        {
            if (Weapons != null && Weapons.Count > 1 && CurrentWeapon != null)
            {
                var weaponIndex = Weapons.IndexOf(CurrentWeapon);
                weaponIndex = weaponIndex + 1 <= Weapons.Count - 1 ? weaponIndex + 1 : 0;

                SetWeapon(Weapons[weaponIndex]);
            }
        }

        public void SetWeapons(List<WeaponStats> weapons, int bullets)
        {
            Weapons = weapons;

            this.bullets.AvailableBullets = bullets;

            SetWeapon(Weapons[0]);
        }

        public void SetWeapon(WeaponStats weapon)
        {
            currentWeapon = weapon;

            if (weapon is RangedWeaponStats ranged)
            {
                bullets.SetWeaponBulletsAmount(ranged.BulletsAmount);
                Bullets.Reload();
            }

            OnWeaponChanged();
        }
    }
}
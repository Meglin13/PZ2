using UnityEngine;

namespace Entities.BaseStats
{
    [CreateAssetMenu(fileName = "WeaponStats", menuName = "Stats/WeaponStats/Ranged")]
    public class RangedWeaponStats : WeaponStats
    {
        [SerializeField]
        private BulletScript bulletPrefab;
        public BulletScript BulletPrefab => bulletPrefab;

        [SerializeField]
        private int bulletsAmount;
        public int BulletsAmount => bulletsAmount;

        [SerializeField]
        private float bulletSpeed = 20;
        public float BulletSpeed => bulletSpeed;
    }
}

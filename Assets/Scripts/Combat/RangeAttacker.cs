using Entities;
using Entities.BaseStats;
using Entities.Interfaces;
using ObjectPooling;
using UnityEngine;

namespace Combat.Attackers
{
    public class RangeAttacker : AttackerBase<RangedWeaponStats>
    {
        private BulletsStat bullets;

        [SerializeField]
        private GameObject gunPoint;

        public override void Init(IStat stat) => bullets = (BulletsStat)stat;

        public override void Attack(RangedWeaponStats weapon)
        {
            if (bullets.CurrentValue > 0 & cooldownTimer > weapon.CooldownBetweenAttacks)
            {
                cooldownTimer = 0;

                bullets.ChangeValue();

                var bullet = PoolerScript<BulletScript>.Instance.CreateObject(weapon.BulletPrefab, gunPoint.transform.position);
                bullet.transform.rotation = gunPoint.transform.rotation;
                bullet.RB.velocity = bullet.transform.up * weapon.BulletSpeed;
            }
        }
    }
}
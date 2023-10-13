using Entities.BaseStats;
using Entities.Interfaces;
using System;
using UnityEngine;

namespace Combat.Attackers
{
    public class MeleeAttacker : AttackerBase<MeleeWeaponStats>
    {
        [SerializeField]
        private LayerMask enemyLayer;

        public override void Init(IStat stat) { }

        public override void Attack(MeleeWeaponStats weapon)
        {
            if (cooldownTimer >= weapon.CooldownBetweenAttacks)
            {
                cooldownTimer = 0;
                    
                Collider2D[] colliders = Physics2D.OverlapCircleAll((Vector2)transform.position, weapon.AttackRange, enemyLayer);

                foreach (Collider2D collider in colliders)
                {
                    if (collider.TryGetComponent(out IDamageable damageable))
                    {
                        damageable.TakeDamage(-weapon.Damage);
                    }
                }
            }
        }
    }
}

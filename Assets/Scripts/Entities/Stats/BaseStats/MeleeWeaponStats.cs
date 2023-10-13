using UnityEngine;

namespace Entities.BaseStats
{
    [CreateAssetMenu(fileName = "WeaponStats", menuName = "Stats/WeaponStats/Melee")]
    public class MeleeWeaponStats : WeaponStats
    {
        [SerializeField]
        private float attackRange = 3;
        public float AttackRange => attackRange;
    }
}
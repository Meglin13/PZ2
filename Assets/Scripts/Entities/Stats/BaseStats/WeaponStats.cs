using Akaal.PvCustomizer.Scripts;
using UnityEngine;

namespace Entities.BaseStats
{
    public class WeaponStats : ScriptableObject
    {
        [SerializeField]
        [PvIcon]
        private Sprite weaponSprite;
        public Sprite WeaponSprite => weaponSprite;

        [SerializeField]
        private float cooldownBetweenAttacks = 1;
        public float CooldownBetweenAttacks => cooldownBetweenAttacks;

        [SerializeField]
        private int damage = 5;
        public int Damage => damage;
    }
}
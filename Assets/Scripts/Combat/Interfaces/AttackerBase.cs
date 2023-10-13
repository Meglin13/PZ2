using Entities.BaseStats;
using Entities.Interfaces;
using UnityEngine;

namespace Combat
{
    public abstract class AttackerBase<T> : MonoBehaviour where T : WeaponStats
    {
        protected float cooldownTimer;
        public float CooldownTimer => cooldownTimer;

        public virtual void Update() => cooldownTimer += Time.deltaTime;

        public abstract void Init(IStat stat);
        public abstract void Attack(T weapon);
    }
}
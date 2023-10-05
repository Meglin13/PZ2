using MVP.Base.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    [Serializable]
    public class EntityModel : IModel
    {
        [SerializeField]
        protected Stats Stats;

        [SerializeField]
        protected float currentHealth;
        public float CurrentHealth
        {
            get => currentHealth;
            set
            {
                currentHealth = Mathf.Clamp(value, 0, Stats.Health);

                OnHealthChange();

                if (CurrentHealth == 0)
                {
                    OnDeath();
                }
            }
        }

        public event Action OnHealthChange = delegate { };
        public event Action OnDeath = delegate { };

        public EntityModel() { }

        public EntityModel(Stats stats) => OnInit(stats);

        public void OnInit() => CurrentHealth = Stats.Health;

        public void OnInit(Stats stats)
        {
            Stats = stats;
            OnInit();
        }

        public void ChangeHealth(float amount) => CurrentHealth += amount;

        public void ClearEvents()
        {
            List<Action> actions = new List<Action>()
            {
                OnHealthChange, OnDeath
            };

            for (int i = 0; i < actions.Count; i++)
            {
                var del = actions[i];

                var actList = del.GetInvocationList();
                foreach (var act in actList)
                {
                    del -= act as Action;
                }
            }
        }
    }
}
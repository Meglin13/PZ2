using Entities.BaseStats;
using Entities.Interfaces;
using MVP.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Entities
{
    [Serializable]
    public class EntityModel : IModel
    {
        protected List<IStat> statsList = new();

        [SerializeField]
        protected EntityStats Stats;

        [SerializeField]
        private HealthStat health;
        public HealthStat Health => health;

        public void OnInit(EntityStats stats)
        {
            Stats = stats;
            health = new HealthStat(Stats.Health);
            statsList.Add(health);
            OnInit();
        }

        public virtual void OnInit() => Health.CurrentValue = Stats.Health;

        public void ClearEvents()
        {
            foreach (var item in statsList)
            {
                item?.ClearEvents();
            }
        }

        public T GetStat<T>() where T : IStat => statsList.OfType<T>().FirstOrDefault();
    }
}
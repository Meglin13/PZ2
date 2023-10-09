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
        protected List<IStat> statsList = new List<IStat>();

        [SerializeField]
        protected Stats Stats;

        [SerializeField]
        private HealthStat health;
        public HealthStat Health => health;

        public void OnInit(Stats stats)
        {
            Stats = stats;
            statsList.Add(Health);
            OnInit();
        }

        public virtual void OnInit()
        {
            health = new HealthStat(Stats.Health);
            Health.CurrentValue = Stats.Health;
        }

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
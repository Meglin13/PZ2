using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ObjectPooling.Poolers
{
    public class EnemyPooler : PoolerScript<EnemyPresenter>
    {
        [SerializeField]
        private GameObject player;
        public GameObject Player => player;

        //TODO: Методы для обнаружения противника
        public void GetNearestEnemy()
        {

        }

        public void GetNearestEnemyInRadius(float radius)
        {

        }
    }
}

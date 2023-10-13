using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ObjectPooling.Poolers
{
    public class EnemyPooler : PoolerScript<EnemyPresenter>
    {
        [SerializeField]
        private int spawnEnemyCount = 3;

        private List<EnemyPresenter> currentEnemies = new();

        public List<EnemyPresenter> CurrentEnemies 
        { 
            get => currentEnemies; 
            private set => currentEnemies = value; 
        }

        public event Action OnEnemiesDefeated = delegate { };

        //TODO: Учет заспавненных врагов

        public override void Start()
        {
            base.Start();

            for (int i = 0; i < spawnEnemyCount; i++)
            {
                var enemy = CreateObject(objectsList[Random.Range(0, objectsList.Count)].item);

                if (enemy == null)
                {
                    break;
                }

                currentEnemies.Add(enemy);
                enemy.Model.Health.OnValueEmpty += () => EnemyDefeated(enemy);
            }
        }

        private void OnDestroy()
        {
            OnEnemiesDefeated = null;
        }

        private void EnemyDefeated(EnemyPresenter enemy)
        {
            currentEnemies.Remove(enemy);

            if (currentEnemies.Count == 0)
            {
                OnEnemiesDefeated();
            }
        }

        public override EnemyPresenter CreateObject(EnemyPresenter prefab, Vector2 spawnPoint = default)
        {
            var enemy = base.CreateObject(prefab, spawnPoint);

            if (spawnPoint == default)
            {
                enemy.gameObject.SetActive(true);
                enemy.transform.position = GetRandomSpawnPoint(); 
            }

            return enemy;
        }
    }
}
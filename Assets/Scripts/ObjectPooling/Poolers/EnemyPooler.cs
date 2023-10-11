using UnityEngine;

namespace ObjectPooling.Poolers
{
    public class EnemyPooler : PoolerScript<EnemyPresenter>
    {
        [SerializeField]
        private int spawnEnemyCount = 3;

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
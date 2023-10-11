using UnityEngine;

namespace ObjectPooling
{
    public class PoolerScript<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static PoolerScript<T> Instance;

        public void Initialize() => Instance = this;

        [SerializeField]
        protected int poolCount = 10;

        [SerializeField]
        private bool autoExpand = false;

        private ObjectPool<T> pool;

        [SerializeField]
        protected ObjectAmountList<T> objectsList;

        [SerializeField]
        protected float spawnRadius;

        public virtual void Start()
        {
            Initialize();

            pool = new ObjectPool<T>(objectsList, poolCount, gameObject.transform)
            {
                AutoExpand = autoExpand
            };
        }

        public virtual T CreateObject(T prefab, Vector2 spawnPoint = default)
        {
            var obj = pool.GetFreeElement(prefab);
            obj.gameObject.transform.position = spawnPoint;

            return obj;
        }

        protected Vector3 GetRandomSpawnPoint()
        {
            Vector2 randomPoint = Random.insideUnitCircle * spawnRadius;
            return transform.position + new Vector3(randomPoint.x, randomPoint.y, 0f);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
    }
}
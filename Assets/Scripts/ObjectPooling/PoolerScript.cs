using UnityEngine;

namespace ObjectPooling
{
    public class PoolerScript<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static PoolerScript<T> Instance;

        public void Initialize() => Instance = this;

        [SerializeField]
        private int poolCount = 10;

        [SerializeField]
        private bool autoExpand = false;

        internal ObjectPool<T> pool;

        public ObjectAmountList<T> objectsList;

        public void Start()
        {
            Initialize();

            pool = new ObjectPool<T>(objectsList, poolCount, gameObject.transform)
            {
                AutoExpand = autoExpand
            };
        }

        public virtual T CreateObject(T prefab, Vector3 spawnPoint)
        {
            var obj = pool.GetFreeElement(prefab);
            obj.gameObject.transform.position = spawnPoint;

            return obj;
        }
    }
}
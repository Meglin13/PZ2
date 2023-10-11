using System;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{
    /// <summary>
    /// Класс для пула объектов
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private ObjectAmountList<T> Prefabs { get; }
        public bool AutoExpand { get; set; }
        public Transform Container { get; }

        private List<T> pool;

        public ObjectPool(ObjectAmountList<T> prefabs, int count, Transform container)
        {
            this.Prefabs = prefabs;
            this.Container = container;

            this.CreatePool();
        }

        /// <summary>
        /// Создание пула
        /// </summary>
        private void CreatePool()
        {
            this.pool = new List<T>();

            foreach (var item in Prefabs.GetList())
            {
                CreateObject(item);
            }
        }

        /// <summary>
        /// Создание объектов на сцене
        /// </summary>
        /// <param name="prefab">Префаб объекта</param>
        /// <param name="isActiveByDiffault">Определяет, будет ли объект активным после создания</param>
        /// <returns></returns>
        private T CreateObject(T prefab, bool isActiveByDiffault = false)
        {
            var createdObject = UnityEngine.Object.Instantiate(prefab, Container);

            createdObject.gameObject.SetActive(isActiveByDiffault);
            createdObject.gameObject.transform.SetParent(Container);

            pool.Add(createdObject);

            return createdObject;
        }

        /// <summary>
        /// Проверка на наличие объекта в пуле
        /// </summary>
        /// <param name="prefab"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        private bool HasFreeElement(T prefab, out T element)
        {
            foreach (var item in pool)
            {
                if (!item.gameObject.activeInHierarchy &
                    item.gameObject.name == string.Format("{0}(Clone)", prefab.gameObject.name))
                {
                    element = item;
                    item.gameObject.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }

        public T GetFreeElement(T prefab)
        {
            if (HasFreeElement(prefab, out var element))
                return element;

            if (AutoExpand)
                return CreateObject(prefab, true);

            return null;
        }
    }
}
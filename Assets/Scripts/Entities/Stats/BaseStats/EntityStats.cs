using UnityEngine;

namespace Entities.BaseStats
{
    [CreateAssetMenu(fileName = "EntityStats", menuName = "Stats/EntityStats")]
    public class EntityStats : ScriptableObject
    {
        [SerializeField]
        private int health = 100;
        public int Health => health;

        [SerializeField]
        private float speed = 5;
        public float Speed => speed;
    }
}
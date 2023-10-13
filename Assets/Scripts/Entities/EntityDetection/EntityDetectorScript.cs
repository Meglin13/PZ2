using UnityEngine;

namespace Entities
{
    public class EntityDetectorScript : MonoBehaviour
    {
        [SerializeField] 
        private float detectionRadius = 2.0f;

        [SerializeField] 
        private LayerMask enemyLayer;

        public Collider2D[] DetectedEnemies { get; private set; }

        public GameObject NearestEntity { get; private set; }

        private void Update()
        {
            CheckForEnemies();
        }

        public void CheckForEnemies()
        {
            DetectedEnemies = Physics2D.OverlapCircleAll(transform.position, detectionRadius, enemyLayer);
            NearestEntity = FindClosestEnemy(DetectedEnemies, transform.position);
        }

        public GameObject FindClosestEnemy(Collider2D[] entitites, Vector2 gameObjectPosition)
        {
            GameObject closestEnemy = null;
            float closestDistance = float.MaxValue;

            foreach (var enemyCollider in entitites)
            {
                Vector2 enemyPosition = enemyCollider.transform.position;
                float distance = Vector2.Distance(gameObjectPosition, enemyPosition);

                if (distance < closestDistance)
                {
                    closestDistance = distance;

                    if (enemyCollider.gameObject.activeInHierarchy)
                    {
                        closestEnemy = enemyCollider.gameObject;
                    }
                }
            }

            return closestEnemy;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
}

using Entities.BaseStats;
using Entities.Interfaces;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    public Rigidbody2D RB => rb;

    [SerializeField]
    private WeaponStats weaponStats;

    private void OnEnable()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out var damageable) & 
            collision.gameObject.layer != gameObject.layer)
        {
            damageable.TakeDamage(-weaponStats.Damage);
        }

        gameObject.SetActive(false);
    }
}
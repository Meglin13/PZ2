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
        if (collision.gameObject.TryGetComponent<EnemyPresenter>(out var presenter))
        {
            presenter.Model.Health.ChangeValue(-weaponStats.Damage);
        }

        gameObject.SetActive(false);
    }
}
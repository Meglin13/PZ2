using Akaal.PvCustomizer.Scripts;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "Stats/WeaponStats")]
public class WeaponStats : ScriptableObject
{
    [SerializeField]
    [PvIcon]
    private Sprite weaponSprite;
    public Sprite WeaponSprite => weaponSprite;

    [SerializeField]
    private BulletScript bulletPrefab;
    public BulletScript BulletPrefab => bulletPrefab;

    [SerializeField]
    private int bulletsAmount;
    public int BulletsAmount => bulletsAmount;

    [SerializeField]
    private float cooldownBetweenShots;
    public float CooldownBetweenShots => cooldownBetweenShots;

    [SerializeField]
    private float bulletSpeed;
    public float BulletSpeed => bulletSpeed;

    [SerializeField]
    private int damage;
    public int Damage => damage;
}
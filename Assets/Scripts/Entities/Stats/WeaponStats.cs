using UnityEngine;

[CreateAssetMenu(fileName = "Stats/WeaponStats", menuName = "WeaponStats")]
public class WeaponStats : ScriptableObject
{
    [SerializeField]
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
    private float damage;
    public float Damage => damage;
}
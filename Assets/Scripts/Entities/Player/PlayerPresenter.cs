using InventorySystem.Inventory;
using InventorySystem.Items;
using ObjectPooling;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Entities.Player
{
    public class PlayerPresenter : EntityPresenter<PlayerModel, PlayerView>
    {
        private InventoryPlayerMediator mediator;

        [SerializeField]
        private List<WeaponStats> weapons;

        [SerializeField]
        private GameObject gunPoint;

        public GameObject GunPoint => gunPoint;

        private float bulletCooldownTimer;
        private float weaponChangeCooldownTimer;

        [SerializeField]
        private float weaponChangeCooldown = 2;

        [SerializeField]
        private int bullets = 50;

        [SerializeField]
        private EntityDetectorScript detector;

        public override void Initialize()
        {
            base.Initialize();

            model.SetWeapons(weapons, bullets);

            model.Bullets.OnValueChanged += () => view.UpdateView();
            model.OnWeaponChanged += () => view.UpdateView();

            view.UpdateView();
        }

        private void Update()
        {
            bulletCooldownTimer += Time.deltaTime;
            weaponChangeCooldownTimer += Time.deltaTime;

            if (detector.NearestEntity != null)
            {
                RotateGunPoint(detector.NearestEntity.transform);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Item"))
            {
                Item item = collision.gameObject.GetComponent<ItemScript>().Item;
                mediator.PlayerPickedUpItem(item);
                collision.gameObject.SetActive(false);
            }
        }

        public void Attack()
        {
            if (model.Bullets.CurrentValue > 0 & bulletCooldownTimer > model.CurrentWeapon.CooldownBetweenShots)
            {
                bulletCooldownTimer = 0;

                model.Bullets.ChangeValue();

                var bullet = PoolerScript<BulletScript>.Instance.CreateObject(model.CurrentWeapon.BulletPrefab, GunPoint.transform.position);
                bullet.transform.rotation = GunPoint.transform.rotation;
                bullet.RB.velocity = bullet.transform.up * model.CurrentWeapon.BulletSpeed;
            }
        }

        public override void Move(Vector2 move)
        {
            base.Move(move);
            RotateGunPoint(move);
        }

        public void RotateGunPoint(Vector2 move)
        {
            if (move != Vector2.zero)
            {
                //GunPoint.transform.localPosition = targetPosition * 2;

                //float rot_z = Mathf.Atan2(targetPosition.y, targetPosition.x) * Mathf.Rad2Deg;
                //GunPoint.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);


                /////////////////////

                float angle = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg;

                GunPoint.transform.rotation = Quaternion.Euler(0f, 0f, angle - 90);

                GunPoint.transform.localPosition = move * 2;

                /////////////////////
            }
        }

        public void RotateGunPoint(Transform target)
        {
            Vector2 direction = ((Vector2)target.position - (Vector2)transform.position).normalized;
            RotateGunPoint(direction);

        }

        public void ChangeWeapon()
        {
            if (weaponChangeCooldownTimer >= weaponChangeCooldown)
            {
                Model.NextWeapon();
                weaponChangeCooldownTimer = 0;
            }
        }

        public string GetBullets() => model.Bullets.CurrentValue + "/" + model.Bullets.AvailableBullets;
        
        public void SetInventoryMediator(InventoryPlayerMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
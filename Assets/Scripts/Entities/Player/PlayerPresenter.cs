using ObjectPooling;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Player
{
    public class PlayerPresenter : EntityPresenter<PlayerModel, PlayerView>
    {
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

        public override void Initialize()
        {
            base.Initialize();

            model.SetWeapons(weapons, bullets);

            model.Bullets.OnValueChanged += () => view.UpdateView();
            model.OnWeaponChanged += () => view.UpdateView(); ;

            view.UpdateView();
        }

        private void Update()
        {
            bulletCooldownTimer += Time.deltaTime;
            weaponChangeCooldownTimer += Time.deltaTime;
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
            if (move != Vector2.zero)
            {
                GunPoint.transform.localPosition = move.normalized * 2;

                float rot_z = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg;
                GunPoint.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            }
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
    }
}
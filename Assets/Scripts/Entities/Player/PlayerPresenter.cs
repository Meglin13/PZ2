using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerPresenter : EntityPresenter<PlayerModel, PlayerView>
    {
        [SerializeField]
        private List<WeaponStats> weapons;

        private float bulletCooldownTimer;

        [SerializeField]
        private int Bullets = 50;

        public override void Initialize()
        {
            base.Initialize();
            
            model.SetWeapons(weapons);

            model.OnBulletsChanged += () => view.UpdateView();
            model.OnWeaponChanged += () => view.UpdateView();

            model.ChangeBullets(50);
        }

        private void Update()
        {
            bulletCooldownTimer += Time.deltaTime;
        }

        public void Attack()
        {
            if (model.CurrentBullets > 0 & bulletCooldownTimer > model.CurrentWeapon.CooldownBetweenShots)
            {
                bulletCooldownTimer = 0;

                model.ChangeBullets();
                var bullet = Instantiate(model.CurrentWeapon.BulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.forward * model.CurrentWeapon.BulletSpeed;
            }
        }

        public string GetBullets()
        {
            return model.CurrentBullets + "/" + model.AvailableBullets;
        }
    }
}
using Combat;
using Combat.Attackers;
using Entities.BaseStats;
using InventorySystem.Inventory;
using InventorySystem.Items;
using SaveLoadSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Entities.Player
{
    public class PlayerPresenter : EntityPresenter<PlayerModel, PlayerView>, ISaveable
    {
        private InventoryPlayerMediator mediator;

        [SerializeField]
        private AttackerBase<RangedWeaponStats> attacker;

        [SerializeField]
        private List<WeaponStats> weapons;

        [SerializeField]
        private GameObject gunPoint;
        public GameObject GunPoint => gunPoint;

        private float weaponChangeCooldownTimer;

        [SerializeField]
        private float weaponChangeCooldown = 2;

        [SerializeField]
        private int bullets = 50;

        public override void Initialize()
        {
            base.Initialize();

            attacker.Init(model.Bullets);

            model.SetWeapons(weapons, bullets);

            model.Bullets.OnValueChanged += () => view.UpdateView();
            model.OnWeaponChanged += () => view.UpdateView();

            view.UpdateView();
        }

        private void Update()
        {
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
            //var attack = attackers.FirstOrDefault(x => x.Stats.GetType() == Model.CurrentWeapon.GetType());

            if (attacker != null)
            {
                attacker.Attack(Model.CurrentWeapon as RangedWeaponStats);
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

        public void SetInventoryMediator(InventoryPlayerMediator mediator) => this.mediator = mediator;

        public object GetObjects()
        {
            var data = new PlayerData
            {
                health = model.Health.CurrentValue,
                bullets = model.Bullets.CurrentValue
            };

            return data;
        }

        public void LoadObjects(object save)
        {
            var data = (PlayerData)save;
            model.Health.CurrentValue = data.health;
            model.Bullets.AvailableBullets = data.bullets;
        }

        [Serializable]
        private struct PlayerData
        {
            public int health;
            public int bullets;
        }
    }
}
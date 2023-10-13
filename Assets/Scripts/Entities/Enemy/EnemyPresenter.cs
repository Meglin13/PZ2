using Combat;
using Entities;
using Entities.BaseStats;
using InventorySystem.Items;
using System.Linq;
using UnityEngine;

public class EnemyPresenter : EntityPresenter<EntityModel, EnemyView>
{
    [SerializeField]
    private AttackerBase<MeleeWeaponStats> attaker;

    [SerializeField]
    private MeleeWeaponStats weaponStats;
    
    [SerializeField]
    private ItemScript item;

    [SerializeField]
    private float itemDropRate = 100;

    public override void Initialize()
    {
        base.Initialize();

        model.Health.OnValueEmpty += Death;

        item.transform.SetParent(null);
        item.gameObject.SetActive(false);

        attaker.Init(null);
    }

    private void Update()
    {
        if (detector.NearestEntity != null)
        {
            Vector2 direction = ((Vector2)detector.NearestEntity.transform.position - (Vector2)transform.position).normalized;

            transform.Translate(direction * EntityStats.Speed * Time.deltaTime);

            attaker.Attack(weaponStats);
        }
    }

    private void Death()
    {
        if (Random.Range(0, itemDropRate) <= itemDropRate)
        {
            item.transform.position = transform.position;
            item.gameObject.SetActive(true);
        }
    }
}
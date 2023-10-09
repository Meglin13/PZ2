using Entities;
using InventorySystem.Items;
using UnityEngine;

public class EnemyPresenter : EntityPresenter<EntityModel, EnemyView>
{
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
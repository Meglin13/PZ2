using Entities;
using UnityEngine;

public class EnemyView : EntityView<EnemyPresenter>
{
    public override void UpdateView()
    {
        healthBar.fillAmount = presenter.GetHealthProcentage();
    }
}
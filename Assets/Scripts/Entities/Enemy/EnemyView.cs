using Entities;
using MVP.Base.Interfaces;
using UnityEngine;

public class EnemyView : EntityView<EnemyPresenter>
{
    public override void OnInit(IPresenter presenter)
    {
        base.OnInit(presenter);
    }

    public override void UpdateView()
    {
        healthBar.fillAmount = presenter.GetHealthProcentage();
    }
}
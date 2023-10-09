using Entities;
using MVP.Base.Interfaces;
using UnityEngine;

public class EnemyView : EntityView<EnemyPresenter>
{
    public override void UpdateView()
    {
        Debug.Log("Bruh");

        healthBar.fillAmount = presenter.GetHealthProcentage();
    }
}
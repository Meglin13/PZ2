using MVP.Base.Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class EntityView<TPresenter> : MonoBehaviour, IView
    where TPresenter : IPresenter
{
    protected TPresenter presenter;
    [SerializeField]
    protected Image healthBar;

    public virtual void OnInit(IPresenter presenter)
    {
        this.presenter = (TPresenter)presenter;
    }

    public virtual void UpdateView() { }
}
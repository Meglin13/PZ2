using MVP.Base.Interfaces;
using UnityEngine;

namespace MVP.Base
{
    public abstract class BaseView<TP> : MonoBehaviour, IView
       where TP : IPresenter
    {
        private TP presenter;
        public TP Presenter => presenter;

        public virtual void OnInit(IPresenter presenter)
        {
            this.presenter = (TP)presenter;
        }

        public abstract void UpdateView();
    }
}
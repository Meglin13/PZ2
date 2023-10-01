using MVP.Base.Interfaces;
using UnityEngine;

namespace MVP.Base
{
    public abstract class BaseView<TP> : MonoBehaviour, IView
       where TP : IPresenter
    {
        public TP Presenter { get; set; }

        public abstract void OnInit(IPresenter presenter);
        public abstract void OnInit();

        public abstract void UpdateView();
    }
}
using MVP.Base.Interfaces;
using UnityEngine;

namespace Assets.Scripts.MVP.Base
{
    public class BasePresenter<TV, TM> : MonoBehaviour, IPresenter
        where TV : IView
        where TM : IModel
    {
        [SerializeField]
        protected TV view;
        protected TM model;

        public void Init(TV view, TM model)
        {
            this.view = view;
            this.model = model;
            this.model.OnInit();
            this.view.OnInit(this);
        }
    }
}

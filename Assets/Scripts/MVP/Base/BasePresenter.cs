using MVP.Base.Interfaces;
using UnityEngine;

namespace MVP.Base
{
    public class BasePresenter<TV, TM> : MonoBehaviour, IPresenter
        where TV : IView
        where TM : IModel, new()
    {
        [SerializeField]
        protected TV view;

        [SerializeField]
        protected TM model = new TM();

        public TM Model => model;

        public virtual void Awake()
        {
            Init(view, model);
        }

        public virtual void Init(TV view, TM model)
        {
            this.view = view;
            this.model = model;
            this.model.OnInit();
            this.view.OnInit(this);
        }
    }
}
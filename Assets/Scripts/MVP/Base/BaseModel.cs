using MVP.Base.Interfaces;
using UnityEngine;

namespace MVP.Base
{
    public abstract class BaseModel<TP> : IModel
        where TP : IPresenter
    {
        private TP presenter;
        public TP Presenter => presenter;

        public BaseModel()
        {
            
        }

        public BaseModel(IPresenter presenter) 
        {
            this.presenter = (TP)presenter;        
        }

        public abstract void OnInit();
    }
}
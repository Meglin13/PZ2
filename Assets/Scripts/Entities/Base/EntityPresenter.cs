using MVP.Base.Interfaces;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class EntityPresenter<TModel, TView> : MonoBehaviour, IPresenter
        where TModel : EntityModel, new()
        where TView : IView
    {
        [SerializeField]
        protected TModel model;

        public TModel Model => model;

        [SerializeField]
        protected TView view;

        [SerializeField]
        protected Stats stats;

        public Stats EntityStats => stats;

        [SerializeField]
        private GameObject Sprite;

        private void Awake() => Initialize();

        private void OnEnable() => model?.OnInit();

        private void OnDestroy() => Uninitialize();

        public virtual void Initialize()
        {
            model = new TModel();

            model.OnInit(stats);
            view.OnInit(this);

            model.Health.OnValueChanged += () => view.UpdateView();
            model.Health.OnValueEmpty += () => gameObject.SetActive(false);
        }

        public void Uninitialize() => model.ClearEvents();

        public virtual void Move(Vector2 move)
        {
            if (move != Vector2.zero)
            {
                transform.Translate(move * Time.deltaTime * EntityStats.Speed);
                var y = move.x < 0 ? 180 : 0;
                Sprite.transform.rotation = new Quaternion(0, y, 0, 0);
            }
        }

        public float GetHealthProcentage() => model.Health.CurrentValue / EntityStats.Health;
    }
}
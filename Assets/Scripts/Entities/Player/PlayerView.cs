using MVP.Base.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerView : EntityView<PlayerPresenter>
    {
        [SerializeField]
        private TextMeshProUGUI bulletsText;
        [SerializeField]
        private PlayerInput input;
        private InputAction moveAction;
        private InputAction fireAction;
        private InputAction inventoryAction;

        public override void OnInit(IPresenter presenter)
        {
            base.OnInit(presenter);

            moveAction = input.actions["Movement"];
            fireAction = input.actions["Fire"];
            inventoryAction = input.actions["Inventory"];

            //fireAction.performed += Fire;
            inventoryAction.performed += Inventory;
        }

        //private void Fire(InputAction.CallbackContext obj)
        //{
        //    presenter.Attack();
        //}

        private void Inventory(InputAction.CallbackContext obj)
        {

        }

        private void Update()
        {
            Vector2 move = moveAction.ReadValue<Vector2>();

            presenter.Move(move);

            if (fireAction.activeControl != null)
            {
                presenter.Attack();
            }
        }

        public override void UpdateView()
        {
            bulletsText.text = presenter.GetBullets();

            healthBar.fillAmount = presenter.GetHealthProcentage();
        }
    }
}
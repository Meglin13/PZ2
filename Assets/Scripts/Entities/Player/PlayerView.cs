using MVP.Base.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Player
{
    public class PlayerView : EntityView<PlayerPresenter>
    {
        [SerializeField]
        private TextMeshProUGUI bulletsText;

        [SerializeField]
        private SpriteRenderer Weapon;

        [SerializeField]
        private PlayerInput input;
        private InputAction moveAction;
        private InputAction fireAction;
        private InputAction inventoryAction;
        private InputAction changeAction;

        public override void OnInit(IPresenter presenter)
        {
            base.OnInit(presenter);

            moveAction = input.actions["Movement"];
            fireAction = input.actions["Fire"];
            inventoryAction = input.actions["Inventory"];
            changeAction = input.actions["ChangeWeapon"];

            changeAction.performed += ChangeWeapon;
            inventoryAction.performed += Inventory;
        }

        //TODO: Сделать везде отписку от событий
        private void OnDestroy()
        {
            changeAction.performed -= ChangeWeapon;
            inventoryAction.performed -= Inventory;
        }

        private void ChangeWeapon(InputAction.CallbackContext obj)
        {
            presenter.ChangeWeapon();
        }

        //TODO: Открытие инвентаря
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

            Weapon.sprite = presenter.Model.CurrentWeapon.WeaponSprite;
        }
    }
}
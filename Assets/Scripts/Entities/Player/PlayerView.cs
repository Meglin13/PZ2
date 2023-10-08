using MVP.Base.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Entities.Player
{
    public class PlayerView : EntityView<PlayerPresenter>
    {
        [SerializeField]
        private GameObject inventory;

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

        private void OnDestroy()
        {
            changeAction.performed -= ChangeWeapon;
            inventoryAction.performed -= Inventory;
        }

        private void ChangeWeapon(InputAction.CallbackContext obj)
        {
            presenter.ChangeWeapon();
        }

        private void Inventory(InputAction.CallbackContext obj)
        {
            inventory.SetActive(!inventory.activeSelf);
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
            //TODO: Перенести в родителя
            healthBar.fillAmount = presenter.GetHealthProcentage();

            bulletsText.text = presenter.GetBullets();

            Weapon.sprite = presenter.Model.CurrentWeapon.WeaponSprite;
        }
    }
}
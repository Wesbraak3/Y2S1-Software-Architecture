using Core.Input;
using UnityEngine;

namespace Entity.Player {

    [RequireComponent(typeof(CharacterController))]
    public class PlayerView : EntityView {
        private CharacterController _characterController;
        public override IInputSource InputSource { get; protected set; }

        protected override void Awake() {
            base.Awake();

            _characterController = GetComponent<CharacterController>();
            InputSource = InputHandler.Instance;
        }
        protected override void Move(Vector2 velocity) {
            _characterController.Move(new(velocity.x, 0, velocity.y));
        }
    }
}
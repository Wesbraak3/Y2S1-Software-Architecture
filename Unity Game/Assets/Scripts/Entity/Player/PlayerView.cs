

using Core.Input;
using JetBrains.Annotations;
using NUnit.Framework.Constraints;
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
            Debug.Log($"Moving charecter by {velocity}");
            _characterController.Move(new(velocity.x, 0, velocity.y));
        }
    }
}
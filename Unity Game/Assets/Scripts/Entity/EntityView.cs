using Core.Input;
using System;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

namespace Entity
{
    public class EntityInformation {
        public Vector3 EntityPosition { get; private set; }
        public Vector3 EntityForward { get; private set; }

        public EntityInformation(Vector3 entityPosition, Vector3 entityForward) {
            EntityPosition = entityPosition;
            EntityForward = entityForward;
        }
    }

    [RequireComponent(typeof(Animator))]
    public abstract class EntityView : MonoBehaviour, IEntityView, IDamagable
    {
        protected Animator _animator;

        public abstract IInputSource InputSource { get; protected set; }

        public event Action<float, Intent, EntityInformation> OnUpdate;
        public event Action OnCollision;
        public event Action OnDamageTaken;

        protected virtual void Awake() {
            _animator = GetComponent<Animator>();

        }

        private void OnCollisionEnter(Collision collision) {
            OnCollision?.Invoke();
        }

        private void Start() {
            if (InputSource == null) {
                Debug.LogError("No Inputsource found");
            }
        }
        private void Update() {
            OnUpdate?.Invoke(
                Time.deltaTime,
                InputSource.BuildIntent(),
                new EntityInformation(
                    gameObject.transform.position, 
                    gameObject.transform.forward
                )
            );
        }
        public void PlayAnimation(AnimationClip animationClip, float speed = 1, float fadeLength = 0.2F)
        {
            Debug.Log($"Play Animation method of {gameObject.name} is not implemented");
            throw new NotImplementedException();
        }

        protected virtual void Move(Vector2 velocity)
        {
            Debug.Log($"Move method of {gameObject.name} is not implemented");
            throw new NotImplementedException();
        }

        public void DamageTaken() => OnDamageTaken?.Invoke();

        void IEntityView.Move(Vector2 velocity) {
            Move(velocity);
        }
    }
}

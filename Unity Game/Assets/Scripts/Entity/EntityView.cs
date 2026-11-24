using Core.Input;
using System;
using UnityEngine;

namespace Entity
{
    [RequireComponent(typeof(Animator))]
    public abstract class EntityView : MonoBehaviour, IEntityView, IDamagable
    {
        protected Animator _animator;

        public abstract IInputSource InputSource { get; protected set; }

        public event Action<float> OnUpdate;
        public event Action<Intent> OnIntent;
        public event Action OnCollision;
        public event Action OnDamageTaken;

        protected virtual void Awake() {
            _animator = GetComponent<Animator>();
        }

        private void OnCollisionEnter(Collision collision) {
            OnCollision?.Invoke();
        }
        private void Update() {
            OnIntent?.Invoke(InputSource.BuildIntent());
            OnUpdate?.Invoke(Time.deltaTime);
        }

        public void PlayAnimation(AnimationClip animationClip, float speed = 1, float fadeLength = 0.2F)
        {
            Debug.Log($"Play Animation method of {this.gameObject.name} is not implemented");
            throw new NotImplementedException();
        }

        protected virtual void Move(Vector2 velocity)
        {
            Debug.Log($"Move method of {this.gameObject.name} is not implemented");
            throw new NotImplementedException();
        }

        public void DamageTaken() => OnDamageTaken?.Invoke();

        void IEntityView.Move(Vector2 velocity) {
            Move(velocity);
        }
    }
}

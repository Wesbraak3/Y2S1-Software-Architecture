using System;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

namespace Entity
{
    [RequireComponent(typeof(Rigidbody), typeof(Animator))]
    public abstract class EntityView : MonoBehaviour, IEntityView, IDamagable
    {
        protected Rigidbody _rigidbody;
        protected Animator _animator;

        [Header("Movement")]
        [SerializeField] private float _moveForce = 30f;
        [SerializeField] private float _maxSpeed = 5f;
        [SerializeField] private float _moveSpeed = 5f;
        private Vector2 _velocity;
        private Vector2 _moveInput;

        public event Action<float> OnUpdate;
        public event Action OnCollision;
        public event Action OnDamageTaken;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();

            _rigidbody.isKinematic = false;
            _rigidbody.useGravity = true;
            _rigidbody.constraints |= RigidbodyConstraints.FreezeRotationX
                                   | RigidbodyConstraints.FreezeRotationZ;

            _animator.applyRootMotion = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            OnCollision?.Invoke();
        }

        private void Update()
        {
            OnUpdate?.Invoke(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            Debug.Log($"Physics input: {_moveInput}");

            Vector3 direction = new Vector3(
                _moveInput.x, 0f, _moveInput.y
            );

            direction = Vector3.ClampMagnitude(direction, 1f);

            Vector3 currentVelocity = _rigidbody.linearVelocity;

            _rigidbody.linearVelocity = new Vector3(
                direction.x * _moveSpeed,
                currentVelocity.y,
                direction.z * _moveSpeed
            );

            Debug.Log($"Rigidbody velocity: {_rigidbody.linearVelocity}");
        }

        public void PlayAnimation(AnimationClip animationClip, float speed = 1, float fadeLength = 0.2F)
        {
            throw new NotImplementedException();
        }

        public void Move(Vector2 velocity)
        {
            // Store input; physics applies the movement in FixedUpdate.
            Debug.Log($"Move called with velocity: {velocity}");
            _moveInput = Vector2.ClampMagnitude(velocity, 1f);
        }

        public void PlayDeath()
        {
            Debug.Log("Entity has died");
            //Destroy(gameObject);
        }

        public void DamageTaken() => OnDamageTaken?.Invoke();
    }
}

using System;
using UnityEngine;
using Core.Interfaces;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Player
{
    [RequireComponent(typeof(CharacterController), typeof(Animator))]
    public class PlayerView : MonoBehaviour/*, IMovable, IDamageAble, IHealAble*/
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Animator _animator;
        
        public event Action<float> Tick;
        
        private void OnEnable()
        {
            if (_characterController == null)
            {
                Debug.LogAssertion("PlayerController is null");
                _characterController = gameObject.GetComponent<CharacterController>();
            }
            if (_animator == null)
            {
                Debug.LogAssertion("animator is null");
                _animator = gameObject.GetComponent<Animator>();
            }
        }

        private void Update() => Tick?.Invoke(Time.deltaTime);
        
        public void Move(Vector3 direction)=> _characterController.Move(direction);

        public void PlayAnimation(string state, float fade, float speed)
        {
        }
    }
}
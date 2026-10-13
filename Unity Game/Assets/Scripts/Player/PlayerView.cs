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
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Animator animator;
        
        public event Action<float> Tick;
        
        private void OnEnable()
        {
            if (characterController == null)
            {
                Debug.LogAssertion("PlayerController is null");
                characterController = gameObject.GetComponent<CharacterController>();
            }
            if (animator == null)
            {
                Debug.LogAssertion("animator is null");
                animator = gameObject.GetComponent<Animator>();
            }
        }

        private void Update() => Tick?.Invoke(Time.deltaTime);
        
        public void Move(Vector3 direction)=> characterController.Move(direction);

        public void PlayAnimation(string state, float fade, float speed)
        {
        }
    }
}
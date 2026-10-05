using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PayerController
{
    public class PlayerMovement : MonoBehaviour
    {
        public Rigidbody rb;
        
        public float movementSpeed = 5;
        private Vector2 _moveDirection;
        
        public InputActionReference move;
        
        void Start()
        {
        
        }

        void Update()
        {
            _moveDirection = move.action.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            rb.linearVelocity = new (_moveDirection.x * movementSpeed, 0, _moveDirection.y * movementSpeed);
        }
    }
}

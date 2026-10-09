using UnityEngine;

namespace Player.Controller
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private float walkSpeed = 4f, runSpeed = 7f;

        private InputHandler _input;

        private CharacterController _controller;
        private Intent _intent;
        private float _velocityY;

        private void Awake()
        {
            _input = InputHandler.Instance;
            _controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            _intent = _input.BuildIntent();
            
            Move();
        }
        
        private void Move()
        {
            Vector3 dir = Vector3.right * _intent.MoveDir.x + Vector3.forward * _intent.MoveDir.y;
            dir = Vector3.ClampMagnitude(dir, 1f);

            float speed = _intent.Sprint ? runSpeed : walkSpeed;

            Vector3 movement = new(0, 0, 0);
            _controller.Move((dir * speed + Vector3.up * _velocityY) * Time.deltaTime);
        }
    }
}
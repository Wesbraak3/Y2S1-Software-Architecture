using System;
using Core.Input;
using Core.Interfaces;
using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerPresenter : ITickable, IDisposable
    {
        public PlayerPresenter(InputHandler input, PlayerView playerView, PlayerModel playerModel)
        {
            _input = input;
            _view = playerView;
            _model = playerModel;

            _view.Tick += Tick;
        }
        
        public void Dispose()
        {
            _view.Tick -= Tick;
        }
        
        // references to other resources
        private readonly InputHandler _input;
        private readonly PlayerView _view;
        private readonly PlayerModel _model;
        
        private Intent intent;
        
        private float walkSpeed = 4f, runSpeed = 7f;
        
        // ReSharper disable Unity.PerformanceAnalysis
        public void Tick(float dt)
        {
            if (dt == 0)
            {
                Debug.LogAssertion("Game Paused?");
                return;
            }

            intent = _input.BuildIntent();
            Move(dt);
        }

        private void Move(float dt)
        {
            Vector3 dir = new Vector3(intent.MoveDir.x, 0f, intent.MoveDir.y);
            dir = Vector3.ClampMagnitude(dir, 1f);

            float speed = intent.Sprint ? runSpeed : walkSpeed;

            Vector3 velocity = dir * speed;
            // later: velocity.y = _verticalVelocity;

            _view.Move(velocity * dt);
        }
    }
}

using System;
using UnityEngine;
using Core.Input;
using Core.Interfaces;
using Core.StateMachine;
using Player.States;

namespace Player
{
    public class PlayerPresenter : IDisposable
    {
        // references to linked resources
        private readonly InputHandler _inputHandler;
        private readonly PlayerView _view;
        private readonly PlayerModel _model;
        private readonly StateMachine _stateMachine;
        
        // Existing States
        public IState Idle { get; }
        public IState Run { get; }
        
        // Player intent based on input
        public Intent Intent { get; private set; }
        
        public PlayerPresenter(InputHandler input, PlayerView playerView, PlayerModel playerModel)
        {
            // Link & Create dependencies
            _inputHandler = input;
            _view = playerView;
            _model = playerModel;
            _stateMachine = new StateMachine();
            
            // Create States
            Idle = new IdleState(this);
            Run = new RunState(this);
            
            // Subscribe to events
            Subscribe();
            
            // Set initial State
            ChangeState(Idle);
        }

        public void Dispose()=> Unsubscribe();

        private void Subscribe()
        {
            _view.Tick += Tick;
        }
        private void Unsubscribe()
        {
            _view.Tick -= Tick;
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        private void Tick(float dt)
        {
            if (dt == 0) return;
            Debug.Log($"CurrentState: {_stateMachine.Current}");
            
            Intent = _inputHandler.BuildIntent();
            _stateMachine.Tick(dt);
        }
        
        // States can use this command
        public void ChangeState(IState next)
        {
            Debug.Log($"{_stateMachine.Current?.GetType().Name} -> {next.GetType().Name}");
            _stateMachine.ChangeState(next);
        }
        
        public void Play(string state, float fade = 0.1f, float speed = 1f) 
            => _view.PlayAnimation(state, fade, speed);
        
        public void ApplyMovement(float dt, float speedMultiplier)
        {
            Vector3 displacement = _model.CaculateDisplacement(dt, Intent);
            _view.Move(displacement);
        }
    }
}

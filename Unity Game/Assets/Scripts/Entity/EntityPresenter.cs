using Core.Input;
using Core.Services.StateMachine;
using System;

namespace Entity
{
    public abstract class EntityPresenter : IDisposable
    {
        protected readonly EntityModel _model;
        protected readonly IEntityView _view;

        protected readonly StateMachine _stateMachine;

        private readonly IInputSource _inputSource;
        protected Intent Intent { get; private set; }

        protected EntityPresenter(IEntityView entityView, IInputSource inputSource, EntityModel entityModel)
        {
            // Link & Create dependencies
            _inputSource = inputSource;
            _view = entityView;
            _model = entityModel;

            _stateMachine = new StateMachine();

            // Subscribe to events
            Subscribe();
        }

        protected abstract void OnTick(float deltaTime);
        protected abstract void OnDeath();

        private void HandleUpdate(float deltaTime)
        {
            Intent = _inputSource.BuildIntent();
            OnTick(deltaTime);
            _stateMachine.Tick(deltaTime);
        }

        protected void Subscribe()
        {
            _view.OnUpdate += HandleUpdate;

            _model.HasDied += OnDeath;
        }
        
        protected void Unsubscribe()
        {
            _view.OnUpdate -= HandleUpdate;

            _model.HasDied -= OnDeath;
        }

        private bool _isDisposed = false;
        public void Dispose()
        {
            if (_isDisposed) return;
            _isDisposed = true;
            
            Unsubscribe();
            _view.PlayDeath();
        }
    }
}

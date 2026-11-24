using Core.Input;
using Core.Services.StateMachine;
using Entity.Player.States;
using System;

namespace Entity
{
    public abstract class EntityPresenter : IDisposable
    {
        public readonly EntityModel _model;
        public readonly IEntityView _view;

        public readonly StateMachine _stateMachine;

        public Intent Intent { get; private set; }
        protected EntityPresenter(IEntityView entityView, EntityModel entityModel)
        {
            // Link & Create dependencies
            _view = entityView;
            _model = entityModel;

            _stateMachine = new StateMachine();

            // Subscribe to events
            Subscribe();
        }
        private void UpdateIntent(Intent intent) => Intent = intent;
        protected abstract void OnDeath();

        private void OnUpdate(float deltaTime) {
            _stateMachine.Tick(deltaTime);
        }
        protected void Subscribe() {
            _view.OnIntent += UpdateIntent;
            _view.OnUpdate += OnUpdate;
            _model.OnDeath += OnDeath;
        }
        protected void Unsubscribe() {
            _view.OnIntent -= UpdateIntent;
            _view.OnUpdate -= OnUpdate;
            _model.OnDeath -= OnDeath;
        }

        private bool _isDisposed = false;
        public void Dispose() {
            if (_isDisposed) return;
            _isDisposed = true;
            
            Unsubscribe();
        }
    }
}

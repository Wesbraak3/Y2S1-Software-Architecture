using UnityEngine;
using Core.Services.StateMachine;

namespace Entity.Player.States
{
    public class IdleState : IState {
        private readonly PlayerPresenter _presenter;

        public IdleState(PlayerPresenter presenter) {
            _presenter = presenter; 
        }


        private float timer = 0f;
        public void Enter() {
            timer = 0f;
        }
        
        public void Tick(float dt) {
            if (_presenter.Intent.MoveDirection != Vector2.zero) {
                _presenter._stateMachine.ChangeState(new MoveState(_presenter));
                return;
            }

            timer += dt;
        }
 
        public void Exit() {
            Debug.Log("Exiting IdleState");
        }
    }
    
    public class MoveState : IState {
        private readonly PlayerPresenter _presenter;

        public MoveState(PlayerPresenter presenter) {
            _presenter = presenter;
        }

        public void Enter() {
        }
 
        public void Tick(float dt) {
            if (_presenter.Intent.MoveDirection == Vector2.zero) {
                _presenter._stateMachine.ChangeState(new IdleState(_presenter));
                return;
            }

            Vector3 movement = _presenter._model.CalculateDisplacement(_presenter.Intent.MoveDirection, dt);
            _presenter._view.Move(movement);
        }
 
        public void Exit() {
            Debug.Log("Exiting MoveState");
        }
    }

    public class AbilityState : IState {
        private readonly PlayerPresenter _presenter;

        public AbilityState(PlayerPresenter presenter) {
            _presenter = presenter;
        }   

        public void Enter() { }

        public void Tick(float dt) {

        }

        public void Exit() { }
    }
}
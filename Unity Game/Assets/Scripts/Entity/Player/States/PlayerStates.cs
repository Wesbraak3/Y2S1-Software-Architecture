using UnityEngine;
using Core.Services.StateMachine;

namespace Entity.Player.States
{
    public class IdleState : IState {
        public PlayerPresenter playerPresenter;
        public IdleState(PlayerPresenter presenter) {
            playerPresenter = presenter;
        }
        
        public void Enter() {
        }
        public void Tick(float dt) {
        }
        public IState? GetNewState() {
            if (playerPresenter.Intent.MoveDirection != Vector2.zero) {
                return new MoveState(playerPresenter);
            }
            return null;
        }

        public void Exit() {
        }
    }
    
    public class MoveState : IState {
        public PlayerPresenter playerPresenter;
        public MoveState(PlayerPresenter presenter) {
            playerPresenter = presenter;

        }

        public void Enter() {
        }
 
        public void Tick(float dt) {
            Vector3 movement = playerPresenter._model.CalculateDisplacement(playerPresenter.Intent.MoveDirection, dt);
            playerPresenter._view.Move(movement);

            // add rotation 
        }
        public IState GetNewState() {
            if (playerPresenter.Intent.MoveDirection == Vector2.zero) {
                return new IdleState(playerPresenter);
            }
            return null;
        }
        public void Exit() {
            Debug.Log("Exiting MoveState");
        }

        
    }

    //public class AbilityState : State {
    //    private readonly PlayerPresenter _presenter;

    //    public AbilityState(PlayerPresenter presenter) {
    //        _presenter = presenter;
    //    }   

    //    public void Enter(float dt) {
    //        Tick(dt);
    //    }

    //    public void Tick(float dt) {

    //    }

    //    public void Exit() { }
    //}
}
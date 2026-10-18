using Entity.Player;
using Core.Services.StateMachine;

namespace Entity.Player.States
{
    public class IdleState : IState
    {
        readonly PlayerPresenter p;
        public IdleState(PlayerPresenter p) { this.p = p; }

        public void Enter() { }
 
        public void Tick(float dt)
        {
        }
 
        public void Exit() { }
    }
    
    public class MoveState : IState
    {
        readonly PlayerPresenter p;
        public MoveState(PlayerPresenter p) { this.p = p; }

        public void Enter() { }
 
        public void Tick(float dt)
        {

        }
 
        public void Exit() { }
    }

    public class AbilityState : IState
    {
        readonly PlayerPresenter p;
        public AbilityState(PlayerPresenter p) { this.p = p; }

        public void Enter() { }

        public void Tick(float dt)
        {

        }

        public void Exit() { }
    }
}
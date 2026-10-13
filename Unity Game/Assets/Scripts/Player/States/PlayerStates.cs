using Core.Interfaces;

namespace Player.States
{
    public class IdleState : IState
    {
        readonly PlayerPresenter p;
        public IdleState(PlayerPresenter p) { this.p = p; }
 
        public void Enter() => p.Play("Idle");
 
        public void Tick(float dt)
        {
            p.ApplyMovement(dt, 0f);
 
            if (p.Intent.MoveDir.sqrMagnitude > 0.01f) p.ChangeState(p.Run);
        }
 
        public void Exit() { }
    }
    
    public class RunState : IState
    {
        readonly PlayerPresenter p;
        public RunState(PlayerPresenter p) { this.p = p; }
 
        public void Enter() => p.Play("Run");
 
        public void Tick(float dt)
        {
            p.ApplyMovement(dt, 1f);
            if (p.Intent.MoveDir.sqrMagnitude <= 0.01f) p.ChangeState(p.Idle);
        }
 
        public void Exit() { }
    }

}
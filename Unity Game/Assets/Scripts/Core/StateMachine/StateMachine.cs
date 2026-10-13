using Core.Interfaces;

namespace Core.StateMachine
{
    public class StateMachine
    {
        public IState Current { get; private set; }

        public void ChangeState(IState next)
        {
            if (next == Current) return;
            Current?.Exit();
            Current = next;
            Current?.Enter();
        }
        
        public void Tick(float dt) => Current?.Tick(dt);
    }
}
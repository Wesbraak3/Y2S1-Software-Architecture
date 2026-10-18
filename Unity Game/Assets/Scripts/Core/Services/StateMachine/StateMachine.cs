namespace Core.Services.StateMachine
{
    public class StateMachine
    {
        public IState CurrentState { get; private set; }

        public void ChangeState(IState nextState)
        {
            if (nextState == CurrentState) return;
            CurrentState?.Exit();
            CurrentState = nextState;
            CurrentState?.Enter();
        }
        
        public void Tick(float deltaTime) => CurrentState?.Tick(deltaTime);
    }
}
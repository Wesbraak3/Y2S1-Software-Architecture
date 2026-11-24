using Entity.Player.States;
using System.Diagnostics;

namespace Core.Services.StateMachine
{
    public class StateMachine
    {
        public IState CurrentState { get; private set; }

        public void ChangeState(IState newState)
        {
            if (CurrentState?.GetType() == newState.GetType()) {
                Debug.Assert(
                    CurrentState?.GetType() != newState.GetType(),
                    $"Cannot transition from {CurrentState?.GetType().Name} to {newState.GetType().Name}: Already in this state."
                );
                return;
            }

            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState?.Enter();
        }
        
        public void Tick(float deltaTime) => CurrentState?.Tick(deltaTime);
    }
}
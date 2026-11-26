using UnityEngine;

namespace Core.Services.StateMachine
{
    public class StateMachine
    {
        public IState CurrentState { get; private set; }
        public float StateTimer = 0;

        public void SetState(IState newState) {
            if (CurrentState != null) {
                CurrentState?.Exit();
            }

            CurrentState = newState;
            CurrentState?.Enter();
        }
        private void ChangeState()
        {
            IState newState = CurrentState.GetNewState();
            if (newState == null) {
                return;
            }

            if (CurrentState?.GetType() == newState.GetType()) {
                Debug.Assert(CurrentState?.GetType() != newState.GetType(),$"Cannot transition from {CurrentState?.GetType().Name} to {newState.GetType().Name}: Already in this state.");
                return;
            }

            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState?.Enter();

            StateTimer = 0;
        }

        public void Tick(float deltaTime) {
            if (CurrentState == null) {
                Debug.Log("No initial state");
                return;
            }

            ChangeState();
            StateTimer += deltaTime;
            CurrentState?.Tick(deltaTime);
        }
    }
}
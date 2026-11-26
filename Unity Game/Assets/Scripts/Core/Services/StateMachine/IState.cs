namespace Core.Services.StateMachine {

    public interface IState {
        public IState GetNewState();
        public void Enter();
        public void Tick(float dt);
        public void Exit();
    }
}
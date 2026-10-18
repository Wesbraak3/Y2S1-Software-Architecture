namespace Core.Services.StateMachine
{
    public interface IState
    {
        void Enter(); 
        void Tick(float dt); 
        void Exit();
    }
}
using Entity.Player.States;

namespace Entity.Player
{
    public class PlayerPresenter : EntityPresenter
    {
        public PlayerPresenter(IEntityView entityView, EntityModel entityModel) : base(entityView, entityModel)
        { 
            _stateMachine.SetState(new IdleState(this));
        }
        protected override void OnDeath()
        {
        }
    }
}

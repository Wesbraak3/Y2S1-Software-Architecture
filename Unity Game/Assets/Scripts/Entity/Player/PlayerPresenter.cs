using Core.Input;
using UnityEngine;

using Entity.Player.States;
using Core.Services.StateMachine;

namespace Entity.Player
{
    public class PlayerPresenter : EntityPresenter
    {
        public PlayerPresenter(IEntityView entityView, EntityModel entityModel) : base(entityView, entityModel)
        { 
            _stateMachine.ChangeState(new IdleState(this));
        } 
        protected override void OnDeath()
        {
        }
    }
}

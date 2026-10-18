using Core.Input;
using UnityEngine;

using Entity.Player.States;

namespace Entity.Player
{
    public class PlayerPresenter : EntityPresenter
    {
        public PlayerPresenter(IEntityView entityView, EntityModel entityModel, IInputSource inputSource) : base(entityView, inputSource, entityModel)
        {
        }

        protected override void OnTick(float deltaTime)
        {
            _view.Move(_model.CalculateDisplacement(Intent.MoveDirection));
        }

        protected override void OnDeath()
        {
            _view.PlayDeath();
        }
    }
}

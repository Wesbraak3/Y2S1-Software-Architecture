using Entity;
using Core.Input;

namespace Entity.Player
{
    public class PlayerModel : EntityModel
    {
        public PlayerModel(int maxHealth) : base(maxHealth)
        {
        }

        protected override void OnDeath()
        {
            // respawn
            // Show game over screen
        }
    }
}
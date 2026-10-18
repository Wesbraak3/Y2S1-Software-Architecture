using Core.Input;
using Entity.Player;

namespace Entity
{
    public static class EntityFactory
    {
        public static EntityPresenter CreateEntity(bool unitTest = false)
        {
            PlayerModel playerModel = new(5);
            PlayerView playerView = new();

            return new PlayerPresenter(playerView, playerModel, InputHandler.Instance);
        }
    }
}

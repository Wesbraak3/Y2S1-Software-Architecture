using Core.Input;
using Entity;

public class PlayerPresenterTest : EntityPresenter
{
    public PlayerPresenterTest(IEntityView entityView, IInputSource inputSource, EntityModel entityModel) : base(entityView, inputSource, entityModel)
    {
    }

    protected override void OnDeath()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnTick(float deltaTime)
    {
        throw new System.NotImplementedException();
    }
}

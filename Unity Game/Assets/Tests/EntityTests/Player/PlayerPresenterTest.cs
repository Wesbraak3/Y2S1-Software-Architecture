using Core.Input;
using Entity;

public class PlayerPresenterTest : EntityPresenter
{
    public PlayerPresenterTest(IEntityView entityView, EntityModel entityModel) : base(entityView, entityModel)
    {
    }
    protected override void OnDeath()
    {
        throw new System.NotImplementedException();
    }
}

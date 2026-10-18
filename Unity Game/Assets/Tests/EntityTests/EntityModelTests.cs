using Entity.Player;
using NUnit.Framework;

public class EntityModelTests
{
    private PlayerModel _model;
    private int _playerMaxHealth = 5;

    [SetUp]
    public void Setup()
    {
        _model = new PlayerModel(_playerMaxHealth);
    }

    [Test]
    public void TakeDamageReducesHealth()
    {
        _model.TakeDamage(_playerMaxHealth - 1);
        Assert.AreEqual(1, _model.Health);
    }

    [Test]
    public void HealthCannotBeNegative()
    { 
        _model.TakeDamage(_playerMaxHealth);
        _model.TakeDamage(_playerMaxHealth);

        Assert.AreEqual(0, _model.Health);
    }

    [Test]
    public void DiedFiresOnceWhenHealthIsZero()
    {
        int _diedEventFired = 0;
        _model.HasDied += () => _diedEventFired++;

        _model.TakeDamage(_playerMaxHealth);
        _model.TakeDamage(_playerMaxHealth);

        Assert.AreEqual(1, _diedEventFired);
    }
}

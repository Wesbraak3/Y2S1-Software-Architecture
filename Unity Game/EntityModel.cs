using System;

public abstract class EntityModel
{
    public int MaxHealth { get; private set; }
    public int Health { get; private set; }
    public bool IsDead { get; private set; }

    public event EventHandler HasDied;

    public abstract void TakeDamage();
    public abstract void OnDeath();
}
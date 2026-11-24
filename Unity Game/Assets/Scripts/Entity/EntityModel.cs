using System;
using UnityEngine;
using System.Reflection;

namespace Entity
{
    public abstract class EntityModel : IDisposable
    {
        public int MaxHealth { get; private set; }
        public int Health { get; private set; }
        public float Speed { get; protected set; } = 5f;

        public event Action OnDeath;

        protected EntityModel(int maxHealth)
        {
            if (maxHealth <= 0)
                throw new ArgumentException("Max health must be greater than zero.", nameof(maxHealth));

            MaxHealth = maxHealth;
            Health = maxHealth;
        }

        public bool IsDead() => Health <= 0;


        public Vector2 CalculateDisplacement(Vector2 direction, float deltaTime)
        {            
            return Vector2.Normalize(direction) * Speed * deltaTime;
        }

        public void SetHealth(int health)
        {
            if (health < 0 || health > MaxHealth)
                throw new ArgumentOutOfRangeException(nameof(health), $"Health must be between 0 and {MaxHealth}.");
            Health = health;
        }

        public void TakeDamage(int amount)
        {
            if (IsDead())
                return;

            Health -= amount;

            if (Health <= 0)
            {
                Health = 0;
                OnDeath?.Invoke();
                HandleDeath();
            }
        }

        public void Heal(int amount)
        {
            if (IsDead())
                return;
            Health += amount;
            if (Health > MaxHealth)
                Health = MaxHealth;
        }



        protected abstract void HandleDeath();

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
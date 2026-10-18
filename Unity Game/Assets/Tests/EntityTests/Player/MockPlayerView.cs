using System;
using UnityEngine;

namespace Assets.Tests.EntityTests.Player
{
    internal class MockPlayerView : IEntityView
    {
        public event Action<float> OnUpdate;
        public event Action OnCollision; 

        public void Move(Vector2 velocity)
        {
            throw new NotImplementedException();
        }

        public void PlayAnimation(AnimationClip animationClip, float speed = 1, float fadeLength = 0.2F)
        {
            throw new NotImplementedException();
        }

        public void PlayDeath()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using UnityEngine;

public interface IEntityView
{
    public event Action<float> OnUpdate;
    public event Action OnCollision;

    public void PlayAnimation(AnimationClip animationClip, float speed = 1f, float fadeLength = 0.2f);
    public void Move(Vector2 velocity);
    public void PlayDeath();
}
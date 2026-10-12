using UnityEngine;

namespace Core.Interfaces
{
    public interface IPlayerInfo
    {
        float Health { get; }
        Vector3 Position { get; }
    }
}
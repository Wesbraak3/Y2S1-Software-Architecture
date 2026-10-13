using UnityEngine;
using Core.Input;

namespace Player
{
    public class PlayerBaseStats
    {
        public Vector3 position;
        public Quaternion rotation;
        public float walkSpeed = 4f, runSpeed = 7f;
    }

    public class PlayerCurrentStats
    {
        
    }
    
    public class PlayerModel
    {
        public PlayerModel(/*player save data*/)
        {
            // load player save data;
            _playerBaseStats = new PlayerBaseStats();
            _playerCurrentStats = new PlayerCurrentStats();
        }

        private readonly PlayerBaseStats _playerBaseStats;
        private readonly PlayerCurrentStats _playerCurrentStats;
        
        public Vector3 CaculateDisplacement(float dt, Intent intent)
        {
            Vector3 dir = new Vector3(intent.MoveDir.x, 0f, intent.MoveDir.y);
            dir = Vector3.ClampMagnitude(dir, 1f);

            float speed = intent.Sprint ? _playerBaseStats.runSpeed : _playerBaseStats.walkSpeed;

            Vector3 velocity = dir * speed;
            // later: velocity.y = _verticalVelocity;

            return velocity * dt;
        }
    }
}
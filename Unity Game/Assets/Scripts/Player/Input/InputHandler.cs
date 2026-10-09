using System;
using UnityEngine;

namespace Player.Controller
{
    public struct Intent
    {
        public Vector2 MoveDir;
        public bool Sprint;
    }
    
    public enum InputContext { Gameplay, UI }
    
    
    public sealed class InputHandler
    {
        private static InputHandler _instance;
        private readonly PlayerInputActions _input;

        private InputHandler()
        {
            _input = new PlayerInputActions();
            SetContext(InputContext.Gameplay);
        }
        
        public static InputHandler Instance
        {
            get
            {
                _instance ??= new InputHandler();
                return _instance;
            }
        }
        
        public void Dispose()
        {
            _input.Disable();
            _input.Dispose();
            
            _instance = null;
        }
        
        public Intent BuildIntent()
        {
            var intent = new Intent
            {
                MoveDir = _input.Gameplay.MoveDir.ReadValue<Vector2>(),
                Sprint = _input.Gameplay.Sprint.IsPressed()
            };

            return intent;
        }
        
        public void SetContext(InputContext context)
        {
            _input.Disable(); 
            
            switch (context)
            {
                case InputContext.Gameplay :
                    _input.Gameplay.Enable();
                    break;
                
                case InputContext.UI:
                    _input.UI.Enable();
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(context), context, null);
            }
        }
    }
}
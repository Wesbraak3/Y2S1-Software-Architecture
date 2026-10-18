using System;
using UnityEngine;

namespace Core.Input
{
    public struct Intent
    {
        public Vector2 MoveDirection;
        public bool SprintPressed;
        public bool AttackPressed;
        public bool DashPressed;
    }
    
    public enum InputContext { Gameplay, UI }

    /// <summary>
    /// Singleton input source that reads player input via PlayerInputActions and constructs Intent instances for
    /// gameplay logic.
    /// 
    /// Later this logic will sample player's keybinds and constructs a general intent for the entitymodel to consume.
    /// This is not a Monobehaviour, as the input system needs to be active whetever there is a player entity or not.
    /// 
    /// </summary>
    /// <remarks>Access the instance through InputHandler.Instance. Call Dispose to disable and dispose the
    /// underlying PlayerInputActions and clear the singleton. Use SetContext to switch action maps between Gameplay and
    /// UI; BuildIntent samples the current gameplay inputs into an Intent.</remarks>
    public sealed class InputHandler : IDisposable, IInputSource
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

        /// <summary>
        /// Builds an Intent populated with the current input state: MoveDirection, SprintPressed, AttackPressed, and DashPressed.
        /// 
        /// TODO: refactor this to be generic not tied to gameply only
        /// TODO: refactor to use player's kebinding instead of hardcoded keys
        /// </summary>
        /// <returns>An Intent whose properties reflect the current gameplay input (move direction vector, sprint flag, and
        /// one-frame attack and dash triggers).</returns>
        public Intent BuildIntent()
        {
            var intent = new Intent
            {
                MoveDirection = _input.Gameplay.MoveDir.ReadValue<Vector2>(),
                SprintPressed = _input.Gameplay.Sprint.IsPressed(),
                AttackPressed = _input.Gameplay.Attack.WasPressedThisFrame(),
                DashPressed = _input.Gameplay.Dash.WasPressedThisFrame()
            };

            return intent;
        }
        
        /// <summary>
        /// Sets the active input context and enables the corresponding input actions.
        /// </summary>
        /// <remarks>Disables all input before enabling the requested context.</remarks>
        /// <param name="context">The input context to activate.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when an unsupported InputContext value is provided.</exception>
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
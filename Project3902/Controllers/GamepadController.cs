using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Project3902
{
    class GamepadController : IController<Buttons>
    {
        private GamePadState currentState;
        private GamePadState prevState;

        private readonly Dictionary<Buttons, ICommand> heldKeys;
        private readonly Dictionary<Buttons, ICommand> pressedKeys;
        private readonly Dictionary<Buttons, ICommand> releasedKeys;

        public GamepadController()
        {
            heldKeys = new Dictionary<Buttons, ICommand>();
            pressedKeys = new Dictionary<Buttons, ICommand>();
            releasedKeys = new Dictionary<Buttons, ICommand>();

            currentState = GamePad.GetState(0);
        }
        public void RegisterCommand(Buttons input, ICommand command)
        {
            heldKeys.Add(input, command);
        }

        public void RegisterCommand(Buttons input, ICommand command, InputState state)
        {
            switch (state)
            {
                case InputState.Held:
                    heldKeys.Add(input, command);
                    break;
                case InputState.Pressed:
                    pressedKeys.Add(input, command);
                    break;
                case InputState.Released:
                    releasedKeys.Add(input, command);
                    break;
            }
        }

        public void Update()
        {
            prevState = currentState;
            currentState = GamePad.GetState(0);

            foreach (Buttons button in heldKeys.Keys)
            {
                if (currentState.IsButtonDown(button))
                    heldKeys[button].Execute();
            }

            foreach (Buttons button in pressedKeys.Keys)
            {
                if (currentState.IsButtonDown(button) && !prevState.IsButtonDown(button))
                {
                    pressedKeys[button].Execute();
                }
            }

            foreach (Buttons button in releasedKeys.Keys)
            {
                if (!currentState.IsButtonDown(button) && prevState.IsButtonDown(button))
                {
                    releasedKeys[button].Execute();
                }
            }
        }
    }
    
}

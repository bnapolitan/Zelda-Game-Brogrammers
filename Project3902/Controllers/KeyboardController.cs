using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class KeyboardController : IController<Keys>
    {
        private Dictionary<Keys, ICommand> heldKeys;
        private Dictionary<Keys, ICommand> pressedKeys;
        private Dictionary<Keys, ICommand> releasedKeys;

        private KeyboardState currentState;
        private KeyboardState previousState;

        public KeyboardController()
        {
            heldKeys = new Dictionary<Keys, ICommand>();
            pressedKeys = new Dictionary<Keys, ICommand>();
            releasedKeys = new Dictionary<Keys, ICommand>();

            currentState = Keyboard.GetState();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            heldKeys.Add(key, command);
        }

        public void RegisterCommand(Keys key, ICommand command, InputState state)
        {
            switch (state)
            {
                case InputState.Held:
                    heldKeys.Add(key, command);
                    break;
                case InputState.Pressed:
                    pressedKeys.Add(key, command);
                    break;
                case InputState.Released:
                    releasedKeys.Add(key, command);
                    break;
            }
        }

        public void Update()
        {
            previousState = currentState;
            currentState = Keyboard.GetState();

            foreach (Keys key in heldKeys.Keys)
            {
                if (currentState.IsKeyDown(key))
                    heldKeys[key].Execute();
            }

            foreach (Keys key in pressedKeys.Keys)
            {
                if (currentState.IsKeyDown(key) && !previousState.IsKeyDown(key))
                {
                    pressedKeys[key].Execute();
                }
            }

            foreach (Keys key in releasedKeys.Keys)
            {
                if (!currentState.IsKeyDown(key) && previousState.IsKeyDown(key))
                {
                    releasedKeys[key].Execute();
                }
            }
        }
    }
}

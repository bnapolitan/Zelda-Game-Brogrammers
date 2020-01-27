using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class KeyboardController : IController<Keys>
    {
        private Dictionary<Keys, ICommand> keyboardMappings;

        public KeyboardController()
        {
            keyboardMappings = new Dictionary<Keys, ICommand>();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            keyboardMappings.Add(key, command);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (keyboardMappings.ContainsKey(key))
                    keyboardMappings[key].Execute();
            }
        }
    }
}

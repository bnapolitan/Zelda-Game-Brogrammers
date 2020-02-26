using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class ItemReg : IController<Keys>
    {
        public Dictionary<Keys, ICommand> ItemCtlKey;
        public FinalGame Game { get; set; }


        public ItemReg()
        {
            ItemCtlKey = new Dictionary<Keys, ICommand>();
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (ItemCtlKey.ContainsKey(key))
                    ItemCtlKey[key].Execute();
            }
        }

        public void RegisterCommand(Keys input, ICommand command, InputState state)
        {
            ItemCtlKey.Add(input, command);
        }

        public void RegisterCommand(Keys input, ICommand command)
        {
            ItemCtlKey.Add(input, command);
        }
    }
}

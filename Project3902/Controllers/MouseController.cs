using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class MouseController : IController<MouseActions>
    {
        private Dictionary<MouseActions, ICommand> mouseMappings;

        public MouseController()
        {
            mouseMappings = new Dictionary<MouseActions, ICommand>();
        }

        public void RegisterCommand(MouseActions button, ICommand command)
        {
            mouseMappings.Add(button, command);
        }

        public void Update()
        {
            MouseState state = Mouse.GetState();

            if (mouseMappings.ContainsKey(MouseActions.Left))
                if (state.LeftButton == ButtonState.Pressed)
                    mouseMappings[MouseActions.Left].Execute();

            if (mouseMappings.ContainsKey(MouseActions.Middle))
                if (state.MiddleButton == ButtonState.Pressed)
                    mouseMappings[MouseActions.Middle].Execute();

            if (mouseMappings.ContainsKey(MouseActions.Right))
                if (state.RightButton == ButtonState.Pressed)
                    mouseMappings[MouseActions.Right].Execute();
        }
    }
}
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
        private bool isLeftPressed = false;
        private bool isRightPressed = false;
        private bool isMiddlePressed = false;

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
            {
                if (state.LeftButton == ButtonState.Pressed && !isLeftPressed)
                {
                    mouseMappings[MouseActions.Left].Execute();
                    isLeftPressed = true;
                }
                if(state.LeftButton == ButtonState.Released)
                {
                    isLeftPressed = false;
                }
            }

            if (mouseMappings.ContainsKey(MouseActions.Middle))
            {
                if (state.MiddleButton == ButtonState.Pressed && !isMiddlePressed)
                {
                    mouseMappings[MouseActions.Middle].Execute();
                    isMiddlePressed = true;
                }
                if (state.MiddleButton == ButtonState.Released)
                {
                    isMiddlePressed = false;
                }
            }

            if (mouseMappings.ContainsKey(MouseActions.Right))
            {
                if (state.RightButton == ButtonState.Pressed && !isRightPressed)
                {
                    mouseMappings[MouseActions.Right].Execute();
                    isRightPressed = true;
                }
                if (state.RightButton == ButtonState.Released)
                {
                    isRightPressed = false;
                }
            }
        }
    }
}
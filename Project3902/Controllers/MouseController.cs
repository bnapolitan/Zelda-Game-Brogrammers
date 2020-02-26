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
        private Dictionary<MouseActions, ICommand> continuousActions;
        private Dictionary<MouseActions, ICommand> pressedActions;
        private Dictionary<MouseActions, ICommand> releasedActions;

        private MouseState currentState;
        private MouseState previousState;

        public MouseController()
        {
            continuousActions = new Dictionary<MouseActions, ICommand>();
            pressedActions = new Dictionary<MouseActions, ICommand>();
            releasedActions = new Dictionary<MouseActions, ICommand>();
        }

        public void RegisterCommand(MouseActions button, ICommand command)
        {
            continuousActions.Add(button, command);
        }

        public void RegisterCommand(MouseActions button, ICommand command, InputState state)
        {
            switch(state)
            {
                case InputState.Held:
                    continuousActions.Add(button, command);
                    break;
                case InputState.Pressed:
                    pressedActions.Add(button, command);
                    break;
                case InputState.Released:
                    releasedActions.Add(button, command);
                    break;
            }
        }

        public void Update()
        {
            previousState = currentState;
            currentState = Mouse.GetState();

            HandleHeldActions();

            HandlePressedActions();

            HandleReleasedActions();

        }

        private void HandleHeldActions()
        {
            if (continuousActions.ContainsKey(MouseActions.Left))
            {
                if (currentState.LeftButton == ButtonState.Pressed)
                {
                    continuousActions[MouseActions.Left].Execute();
                }
            }

            if (continuousActions.ContainsKey(MouseActions.Middle))
            {
                if (currentState.MiddleButton == ButtonState.Pressed)
                {
                    continuousActions[MouseActions.Middle].Execute();
                }
            }

            if (continuousActions.ContainsKey(MouseActions.Right))
            {
                if (currentState.RightButton == ButtonState.Pressed)
                {
                    continuousActions[MouseActions.Right].Execute();
                }
            }
        }

        private void HandlePressedActions()
        {
            if (pressedActions.ContainsKey(MouseActions.Left))
            {
                if (currentState.LeftButton == ButtonState.Pressed && previousState.LeftButton == ButtonState.Released)
                {
                    pressedActions[MouseActions.Left].Execute();
                }
            }

            if (pressedActions.ContainsKey(MouseActions.Middle))
            {
                if (currentState.MiddleButton == ButtonState.Pressed && previousState.MiddleButton == ButtonState.Released)
                {
                    pressedActions[MouseActions.Middle].Execute();
                }
            }

            if (pressedActions.ContainsKey(MouseActions.Right))
            {
                if (currentState.RightButton == ButtonState.Pressed && previousState.RightButton == ButtonState.Released)
                {
                    pressedActions[MouseActions.Right].Execute();
                }
            }
        }

        private void HandleReleasedActions()
        {
            if (releasedActions.ContainsKey(MouseActions.Left))
            {
                if (currentState.LeftButton == ButtonState.Released && previousState.LeftButton == ButtonState.Pressed)
                {
                    releasedActions[MouseActions.Left].Execute();
                }
            }

            if (releasedActions.ContainsKey(MouseActions.Middle))
            {
                if (currentState.MiddleButton == ButtonState.Released && previousState.MiddleButton == ButtonState.Pressed)
                {
                    releasedActions[MouseActions.Middle].Execute();
                }
            }

            if (releasedActions.ContainsKey(MouseActions.Right))
            {
                if (currentState.RightButton == ButtonState.Released && previousState.RightButton == ButtonState.Pressed)
                {
                    releasedActions[MouseActions.Right].Execute();
                }
            }
        }
    }
}
﻿using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Project3902
{
    class MouseController : IController<MouseActions>
    {
        private readonly Dictionary<MouseActions, ICommand> continuousActions;
        private readonly Dictionary<MouseActions, ICommand> pressedActions;
        private readonly Dictionary<MouseActions, ICommand> releasedActions;

        private readonly Dictionary<int, ICommand> roomSwitchingActions;

        private MouseState currentState;
        private MouseState previousState;

        public MouseController()
        {
            continuousActions = new Dictionary<MouseActions, ICommand>();
            pressedActions = new Dictionary<MouseActions, ICommand>();
            releasedActions = new Dictionary<MouseActions, ICommand>();
            roomSwitchingActions = new Dictionary<int, ICommand>();
        }

        public void RegisterCommand(int roomNumber, ICommand command)
        {
            roomSwitchingActions.Add(roomNumber, command);
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

            HandleRoomSwitching();
        }

        private void HandleRoomSwitching()
        {
            int xPos = Mouse.GetState().X;
            int yPos = Mouse.GetState().Y;

            int roomNumber = 0;

            if (xPos >= 50 && xPos < 100 && yPos >= 50 && yPos < 100)
            {
                roomNumber = 1;
            }
            else if (xPos >= 100 && xPos < 150 && yPos >= 50 && yPos < 100)
            {
                roomNumber = 2;
            }
            else if (xPos >= 150 && xPos < 200 && yPos >= 50 && yPos < 100)
            {
                roomNumber = 3;
            }
            else if (xPos >= 200 && xPos < 250 && yPos >= 50 && yPos < 100)
            {
                roomNumber = 4;
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && roomNumber != 0)
            {
                roomSwitchingActions[roomNumber].Execute();
            }
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
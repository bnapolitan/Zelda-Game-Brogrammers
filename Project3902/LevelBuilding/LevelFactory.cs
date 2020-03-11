﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace Project3902
{
	class LevelFactory
	{

		public static LevelFactory Instance { get; } = new LevelFactory();

		private LevelFactory()
		{
		}

        public MouseController CreateLevelController(FinalGame game)
        {
            var controller = new MouseController();

            controller.RegisterCommand(MouseActions.Right, new CycleNextRoom(game), InputState.Pressed);
            controller.RegisterCommand(MouseActions.Left, new CyclePrvRoom(game), InputState.Pressed);
            return controller;
        }
        public List<string> CreateRooms()
        {
            var list = new List<string>();
            list.Add("DungeonRoom1");
            list.Add("DungeonRoom2");
            list.Add("DungeonRoom3");
            list.Add("DungeonRoom4");
            list.Add("DungeonRoom5");
            list.Add("DungeonRoom6");
            list.Add("DungeonRoom7");
            list.Add("DungeonRoom8");
            list.Add("DungeonRoom9");
            return list;
        }


    }
}
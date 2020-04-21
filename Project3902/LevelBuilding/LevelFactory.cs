using Microsoft.Xna.Framework;
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

            controller.RegisterCommand(1, new ChangeToRoom1Command(game));
            controller.RegisterCommand(2, new ChangeToRoom2Command(game));
            controller.RegisterCommand(3, new ChangeToRoom3Command(game));
            controller.RegisterCommand(4, new ChangeToRoom4Command(game));
            controller.RegisterCommand(5, new ChangeToRoom5Command(game));
            controller.RegisterCommand(6, new ChangeToRoom6Command(game));
            controller.RegisterCommand(7, new ChangeToRoom7Command(game));
            controller.RegisterCommand(8, new ChangeToRoom8Command(game));
            controller.RegisterCommand(9, new ChangeToRoom9Command(game));
            controller.RegisterCommand(10, new ChangeToRoom10Command(game));
            controller.RegisterCommand(11, new ChangeToRoom11Command(game));
            controller.RegisterCommand(12, new ChangeToRoom12Command(game));
            controller.RegisterCommand(13, new ChangeToRoom13Command(game));
            controller.RegisterCommand(14, new ChangeToRoom14Command(game));
            controller.RegisterCommand(15, new ChangeToRoom15Command(game));
            controller.RegisterCommand(16, new ChangeToRoom16Command(game));
            controller.RegisterCommand(17, new ChangeToRoom17Command(game));
            return controller;
        }
    }
}
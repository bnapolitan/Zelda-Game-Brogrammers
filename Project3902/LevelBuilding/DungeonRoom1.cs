using Microsoft.Xna.Framework;
using Project3902.GameObjects;
using Project3902.GameObjects.Enemies_and_NPCs;
using Project3902.LevelBuilding.Interface;
using Project3902.ObjectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class DungeonRoom1 : ILevel
    {
        public FinalGame Game { get; }
        private EnvironmentFactory envFactory = EnvironmentFactory.Instance;

        public DungeonRoom1(FinalGame game)
        {
            Game = game;
        }

        public List<IGameObject> CreateInteractiveEnvironmentObjects()
        {
            var list = new List<IGameObject>();
            for (int j = 128; j < 650; j += 64)
            {
                for (int i = 128; i < 839; i += 64)
                {
                    list.Add(envFactory.CreateFloorTile(new Vector2(i, j)));
                }
            }

            list.Add(envFactory.CreateLeftStatue(new Vector2(192, 192)));
            list.Add(envFactory.CreateLeftStatue(new Vector2(192, 320)));
            list.Add(envFactory.CreateLeftStatue(new Vector2(192, 448)));
            list.Add(envFactory.CreateLeftStatue(new Vector2(384, 192)));
            list.Add(envFactory.CreateLeftStatue(new Vector2(384, 320)));
            list.Add(envFactory.CreateLeftStatue(new Vector2(384, 448)));

            list.Add(envFactory.CreateRightStatue(new Vector2(576, 192)));
            list.Add(envFactory.CreateRightStatue(new Vector2(576, 320)));
            list.Add(envFactory.CreateRightStatue(new Vector2(576, 448)));
            list.Add(envFactory.CreateRightStatue(new Vector2(768, 192)));
            list.Add(envFactory.CreateRightStatue(new Vector2(768, 320)));
            list.Add(envFactory.CreateRightStatue(new Vector2(768, 448)));

            list.Add(envFactory.CreateRoomBorder(new Vector2(0,0)));
            return list;
        }

        public List<IGameObject> CreateEnemyObjects()
        {
            var list = new List<IGameObject>();
            return list;
        }

    }
}

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
    class DungeonRoom2 : ILevel
    {
        public FinalGame Game { get; }
        private EnvironmentFactory envFactory = EnvironmentFactory.Instance;
        private EnemyFactory enemyFactory = EnemyFactory.Instance;

        public DungeonRoom2(FinalGame game)
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

            list.Add(envFactory.CreateRoomBorder(new Vector2(0,0)));
            return list;
        }

        public List<IGameObject> CreateEnemyObjects()
        {
            var list = new List<IGameObject>();
            list.Add(enemyFactory.CreateBlueKeese(new Vector2(192, 192)));
            list.Add(enemyFactory.CreateBlueKeese(new Vector2(320, 256)));
            list.Add(enemyFactory.CreateBlueKeese(new Vector2(192, 448)));
            return list;
        }

    }
}

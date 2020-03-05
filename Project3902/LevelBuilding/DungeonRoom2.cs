using Microsoft.Xna.Framework;
using Project3902.LevelBuilding;
using Project3902.ObjectManagement;
using System.Collections.Generic;

namespace Project3902
{
    class DungeonRoom2 : ILevel
    {
        public FinalGame Game { get; }
        private readonly EnvironmentFactory envFactory = EnvironmentFactory.Instance;
        private readonly EnemyFactory enemyFactory = EnemyFactory.Instance;

        public DungeonRoom2(FinalGame game)
        {
            Game = game;
        }

        public List<IGameObject> CreateInteractiveEnvironmentObjects()
        {
            var list = new List<IGameObject>
            {
                envFactory.CreateRoomBorder(new Vector2(0, 0))
            };

            for (int j = 128; j < 560; j += 64)
            {
                for (int i = 128; i < 839; i += 64)
                {
                    list.Add(envFactory.CreateFloorTile(new Vector2(i, j)));
                }
            }

            list.Add(envFactory.CreateWallTop(new Vector2(448, 0)));
            list.Add(envFactory.CreateWallLeft(new Vector2(0, 288)));
            list.Add(envFactory.CreateOpenDoorRight(new Vector2(896, 288)));
            list.Add(envFactory.CreateWallBottom(new Vector2(448, 576)));
            return list;
        }

        public List<IGameObject> CreateEnemyObjects()
        {
            var list = new List<IGameObject>
            {
                enemyFactory.CreateBlueKeese(new Vector2(192, 192)),
                enemyFactory.CreateBlueKeese(new Vector2(320, 256)),
                enemyFactory.CreateBlueKeese(new Vector2(192, 448))
            };
            return list;
        }

    }
}

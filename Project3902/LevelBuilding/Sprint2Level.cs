using Microsoft.Xna.Framework;
using Project3902.GameObjects.EnemiesAndNPCs;
using Project3902.ObjectManagement;
using System.Collections.Generic;

namespace Project3902
{
    class Sprint2Level
    {
        public Sprint2 Game { get; }
        private Vector2 environmentPosition;
        private Vector2 enemyPosition;

        public Sprint2Level(Sprint2 game)
        {
            Game = game;
            environmentPosition = new Vector2(450, 50);
            enemyPosition = new Vector2(450, 250);
        }

        public List<IGameObject> CreateInteractiveEnvironmentObjects()
        {
            var list = new List<IGameObject>();
            list.Add(EnvironmentFactory.Instance.CreateStairs(environmentPosition));
            list.Add(EnvironmentFactory.Instance.CreateLadderTile(environmentPosition));
            list.Add(EnvironmentFactory.Instance.CreateGapTile(environmentPosition));
            list.Add(EnvironmentFactory.Instance.CreateFire(environmentPosition));
            list.Add(EnvironmentFactory.Instance.CreateBrickTile(environmentPosition));
            list.Add(EnvironmentFactory.Instance.CreateBombedOpening(environmentPosition));
            list.Add(EnvironmentFactory.Instance.CreateEnemyCloudAppearance(environmentPosition));
            list.Add(EnvironmentFactory.Instance.CreateFloorTile(environmentPosition));
            list.Add(EnvironmentFactory.Instance.CreateRoomBorder(environmentPosition));
            return list;
        }

        public List<IGameObject> CreateEnemyObjects()
        {
            var list = new List<IGameObject>();
            list.Add(EnemyFactory.Instance.CreateAquaGel(enemyPosition));
            list.Add(EnemyFactory.Instance.CreateRedKeese(enemyPosition));
            list.Add(EnemyFactory.Instance.CreateRope(enemyPosition));
            list.Add(EnemyFactory.Instance.CreateStalfos(enemyPosition));
            list.Add(EnemyFactory.Instance.CreateWallmaster(enemyPosition));
            list.Add(EnemyFactory.Instance.CreateGreenZol(enemyPosition));

            var aquamentus = new Aquamentus(enemyPosition, 1, new Vector2(1, 0), this.Game);
            list.Add(aquamentus);
            list.Add(EnemyFactory.Instance.CreateBlueGoriya(enemyPosition));

            list.Add(EnemyFactory.Instance.createGreenMerchant(enemyPosition));
            list.Add(EnemyFactory.Instance.createDongo(enemyPosition));
            list.Add(EnemyFactory.Instance.createOldMan(enemyPosition));
            list.Add(EnemyFactory.Instance.createFlame(enemyPosition));
            return list;
        }

    }
}
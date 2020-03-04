using Microsoft.Xna.Framework;
using Project3902.GameObjects.EnemiesAndNPCs;
using Project3902.LevelBuilding.Interface;
using Project3902.ObjectManagement;
using System.Collections.Generic;

namespace Project3902
{
    class Sprint2Level : ILevel
    {
        public FinalGame Game { get; }
        private Vector2 environmentPosition;
        private Vector2 enemyPosition, itemPosition;

        public Sprint2Level(FinalGame game)
        {
            Game = game;
            environmentPosition = new Vector2(450, 50);
            enemyPosition = new Vector2(450, 250);
            itemPosition = new Vector2(300,300);
        }

        public List<IGameObject> CreateInteractiveEnvironmentObjects()
        {
            var list = new List<IGameObject>
            {
                EnvironmentFactory.Instance.CreateStairs(environmentPosition),
                EnvironmentFactory.Instance.CreateLadderTile(environmentPosition),
                EnvironmentFactory.Instance.CreateGapTile(environmentPosition),
                EnvironmentFactory.Instance.CreateFire(environmentPosition),
                EnvironmentFactory.Instance.CreateBrickTile(environmentPosition),
                EnvironmentFactory.Instance.CreateBombedOpeningTop(environmentPosition),
                EnvironmentFactory.Instance.CreateEnemyCloudAppearance(environmentPosition),
                EnvironmentFactory.Instance.CreateFloorTile(environmentPosition),
                EnvironmentFactory.Instance.CreateRoomBorder(environmentPosition)
            };
            return list;
        }

        public List<IGameObject> CreateEnemyObjects()
        {
            var list = new List<IGameObject>
            {
                EnemyFactory.Instance.CreateAquaGel(enemyPosition),
                EnemyFactory.Instance.CreateRedKeese(enemyPosition),
                EnemyFactory.Instance.CreateRope(enemyPosition),
                EnemyFactory.Instance.CreateStalfos(enemyPosition),
                EnemyFactory.Instance.CreateWallmaster(enemyPosition),
                EnemyFactory.Instance.CreateGreenZol(enemyPosition)
            };

            var aquamentus = new Aquamentus(enemyPosition, 1, new Vector2(1, 0), this.Game);
            aquamentus.Collider= new Collider(aquamentus, new Rectangle(0, 0, 24 * 6, 32 * 6));
            EnemyFactory.RegisterEnemyForCollision(aquamentus);
            list.Add(aquamentus);
            list.Add(EnemyFactory.Instance.CreateBlueGoriya(enemyPosition));

            list.Add(EnemyFactory.Instance.CreateGreenMerchant(enemyPosition));
            list.Add(EnemyFactory.Instance.CreateDongo(enemyPosition));
            list.Add(EnemyFactory.Instance.CreateOldMan(enemyPosition));
            list.Add(EnemyFactory.Instance.CreateFlame(enemyPosition));
            return list;
        }

        public List<IGameObject> CreateItem()
        {
            var list = new List<IGameObject>
            {
                ItemFactory.Instance.CreateHeart(itemPosition),
                ItemFactory.Instance.CreateRupee(itemPosition),
                ItemFactory.Instance.Create1Rupee(itemPosition),
                ItemFactory.Instance.CreateFairy(itemPosition),
                ItemFactory.Instance.CreateWatch(itemPosition),
                ItemFactory.Instance.CreateBow(itemPosition),
                ItemFactory.Instance.CreateKey(itemPosition),
                ItemFactory.Instance.CreateArrow(itemPosition)
            };
            return list;
        }

    }
}

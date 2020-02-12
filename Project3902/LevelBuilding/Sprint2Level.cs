using Microsoft.Xna.Framework;
using Project3902.GameObjects;
using Project3902.ObjectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class Sprint2Level
    {
        private Vector2 environmentPosition;
        private Vector2 enemyPosition;

        public Sprint2Level()
        {
            environmentPosition = new Vector2(400, 200);
            enemyPosition = new Vector2(500, 300);
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
            list.Add(EnemyFactory.Instance.CreateBlueGoriya(enemyPosition));
            list.Add(EnemyFactory.Instance.CreateRedKeese(enemyPosition));
            list.Add(EnemyFactory.Instance.CreateRope(enemyPosition));
            list.Add(EnemyFactory.Instance.CreateStalfos(enemyPosition));
            list.Add(EnemyFactory.Instance.CreateWallmaster(enemyPosition));
            list.Add(EnemyFactory.Instance.CreateGreenZol(enemyPosition));
            list.Add(EnemyFactory.Instance.createAquamentus(enemyPosition));
            list.Add(EnemyFactory.Instance.createRedMerchant(enemyPosition));
            list.Add(EnemyFactory.Instance.createDongo(enemyPosition));
            list.Add(EnemyFactory.Instance.createOldMan(enemyPosition));
            list.Add(EnemyFactory.Instance.createFlame(enemyPosition));
            list.Add(EnemyFactory.Instance.createFireball(enemyPosition));
            return list;
        }
        
    }
}

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

        public Sprint2Level()
        {
            environmentPosition = new Vector2(400, 200);
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
            return list;
        }
        
        public List<IGameObject> CreateEnemyObjects()
        {
            var list = new List<IGameObject>();
            list.Add(EnemyFactory.Instance.CreateAquaGel(new Vector2(400, 200)));
            list.Add(EnemyFactory.Instance.CreateBlueGoriya(new Vector2(400, 200)));
            list.Add(EnemyFactory.Instance.CreateRedKeese(new Vector2(400, 200)));
            list.Add(EnemyFactory.Instance.CreateRope(new Vector2(400, 200)));
            list.Add(EnemyFactory.Instance.CreateStalfos(new Vector2(400, 200)));
            list.Add(EnemyFactory.Instance.CreateWallmaster(new Vector2(400, 200)));
            list.Add(EnemyFactory.Instance.CreateGreenZol(new Vector2(400, 200)));
            list.Add(EnemyFactory.Instance.createAquamentus(new Vector2(400, 200)));
            list.Add(EnemyFactory.Instance.createRedMerchant(new Vector2(400, 200)));
            list.Add(EnemyFactory.Instance.createDongo(new Vector2(400, 200)));
            list.Add(EnemyFactory.Instance.createOldMan(new Vector2(400, 200)));
            list.Add(EnemyFactory.Instance.createFlame(new Vector2(400, 200)));
            list.Add(EnemyFactory.Instance.createFireball(new Vector2(400, 200)));
            return list;
        }
        
    }
}

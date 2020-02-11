using Microsoft.Xna.Framework;
using Project3902.GameObjects;
using Project3902.ObjectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.LevelBuilding.Sprint2Level
{
    class Sprint2Level
    {
        public Sprint2Level()
        {

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
            return list;
        }
    }
}

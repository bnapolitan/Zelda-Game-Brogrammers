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

        public List<IGameObject> CreateInteractiveEnvironmentObjects()
        {
            var list = new List<IGameObject>();
            list.Add(EnvironmentFactory.Instance.CreateStairs(new Vector2(400, 200)));
            list.Add(EnvironmentFactory.Instance.CreateLadderTile(new Vector2(400, 200)));
            list.Add(EnvironmentFactory.Instance.CreateGapTile(new Vector2(400, 200)));
            list.Add(EnvironmentFactory.Instance.CreateFire(new Vector2(400, 200)));
            list.Add(EnvironmentFactory.Instance.CreateBrickTile(new Vector2(400, 200)));
            list.Add(EnvironmentFactory.Instance.CreateBombedOpening(new Vector2(400, 200)));
            return list;
        }
    }
}

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
    }
}

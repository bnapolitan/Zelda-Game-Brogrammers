using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.LevelBuilding.Interface
{
    public interface ILevel
    {
        List<IGameObject> CreateInteractiveEnvironmentObjects();

        List<IGameObject> CreateEnemyObjects();
    }
}

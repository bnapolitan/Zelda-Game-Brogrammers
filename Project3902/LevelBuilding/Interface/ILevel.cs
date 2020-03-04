using System.Collections.Generic;

namespace Project3902.LevelBuilding.Interface
{
    public interface ILevel
    {
        List<IGameObject> CreateInteractiveEnvironmentObjects();

        List<IGameObject> CreateEnemyObjects();
    }
}

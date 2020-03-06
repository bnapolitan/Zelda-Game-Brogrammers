using System.Collections.Generic;

namespace Project3902.LevelBuilding
{
    public interface ILevel
    {
        List<IGameObject> CreateInteractiveEnvironmentObjects();

        List<IGameObject> CreateEnemyObjects();
    }
}

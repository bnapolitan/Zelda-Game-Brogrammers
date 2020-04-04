using System.Collections.Generic;

namespace Project3902.LevelBuilding
{
    public interface ILevelBuilder
    {
        List<IGameObject> CreateInteractiveEnvironmentObjects();

        List<IGameObject> CreateEnemyObjects();
    }
}

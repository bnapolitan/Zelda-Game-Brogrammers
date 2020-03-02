using Microsoft.Xna.Framework;
using Project3902.ObjectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902.LevelBuilding
{
    class ObjectLookup
    {
        public static IDictionary<string, string> ObjectMappings;
        private EnvironmentFactory envFactory = EnvironmentFactory.Instance;
        private EnemyFactory enemyFactory = EnemyFactory.Instance;

        public ObjectLookup()
        {
        }

        public IGameObject CreateEnvironmentObject(string name, Vector2 position)
        {
            if(name == "Dirt")
            {
                return envFactory.CreateFloorTileDirt(position);
            }
            if (name == "LeftStatue")
            {
                return envFactory.CreateLeftStatue(position);
            }
            if (name == "RightStatue")
            {
                return envFactory.CreateRightStatue(position);
            }
            if (name == "LockDoorTop")
            {
                return envFactory.CreateLockDoorTop(position);
            }
            if (name == "LockDoorLeft")
            {
                return envFactory.CreateLockDoorLeft(position);
            }
            if (name == "LockDoorRight")
            {
                return envFactory.CreateLockDoorRight(position);
            }
            if (name == "LockDoorBottom")
            {
                return envFactory.CreateLockDoorBottom(position);
            }
            if (name == "OpenDoorTop")
            {
                return envFactory.CreateOpenDoorTop(position);
            }
            if (name == "OpenDoorLeft")
            {
                return envFactory.CreateOpenDoorLeft(position);
            }
            if (name == "OpenDoorRight")
            {
                return envFactory.CreateOpenDoorRight(position);
            }
            if (name == "OpenDoorBottom")
            {
                return envFactory.CreateOpenDoorBottom(position);
            }
            if (name == "WallTop")
            {
                return envFactory.CreateWallTop(position);
            }
            if (name == "WallLeft")
            {
                return envFactory.CreateWallLeft(position);
            }
            if (name == "WallRight")
            {
                return envFactory.CreateWallRight(position);
            }
            if (name == "WallBottom")
            {
                return envFactory.CreateWallBottom(position);
            }

            throw new Exception($"The object {name} has not been mapped in ObjectLookup yet!");
        }

        public IGameObject CreateEnemyObject(string name, Vector2 position)
        {
            if (name == "BlueKeese")
            {
                return enemyFactory.CreateBlueKeese(position);
            }
            if(name=="AquaGel")
            {
                return enemyFactory.CreateAquaGel(position);
            }
            if (name == "GrayZol")
            {
                return enemyFactory.CreateGrayZol(position);
            }
            throw new Exception($"The object {name} has not been mapped in ObjectLookup yet!");
        }
    }
}

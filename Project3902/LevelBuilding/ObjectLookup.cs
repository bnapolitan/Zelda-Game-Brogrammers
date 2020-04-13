using Microsoft.Xna.Framework;
using Project3902.ObjectManagement;
using System;

namespace Project3902.LevelBuilding
{
    class ObjectLookup
    {

        private readonly EnvironmentFactory envFactory = EnvironmentFactory.Instance;
        private readonly EnemyFactory enemyFactory = EnemyFactory.Instance;
        private readonly ItemFactory itemFactory = ItemFactory.Instance;

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
            if (name == "ShutDoorTop")
            {
                return envFactory.CreateShutDoorTop(position);
            }
            if (name == "ShutDoorLeft")
            {
                return envFactory.CreateShutDoorLeft(position);
            }
            if (name == "ShutDoorRight")
            {
                return envFactory.CreateShutDoorRight(position);
            }
            if (name == "ShutDoorBottom")
            {
                return envFactory.CreateShutDoorBottom(position);
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
            if (name == "Brick")
            {
                return envFactory.CreateBlockingBrick(position);
            }
            if (name == "MoveableBlockUp")
            {
                return envFactory.CreateMoveableBlock(position, new Vector2(0, -1));
            }
            if (name == "MoveableBlockDown")
            {
                return envFactory.CreateMoveableBlock(position, new Vector2(0, 1));
            }
            if (name == "MoveableBlockRight")
            {
                return envFactory.CreateMoveableBlock(position, new Vector2(1, 0));
            }
            if (name == "MoveableBlockLeft")
            {
                return envFactory.CreateMoveableBlock(position, new Vector2(-1, 0));
            }
            if (name == "BlackBackground")
            {
                return envFactory.CreateBlackBackground(position);
            }
            if (name == "Water")
            {
                return envFactory.CreateWater(position);
            }
            if (name == "Stairs")
            {
                return envFactory.CreateStairs(position);
            }

            throw new Exception($"The object {name} has not been mapped in ObjectLookup yet!");
        }

        public IGameObject CreateItemObject(string name, Vector2 position)
        {
            if (name == "5Rupee")
            {
                return itemFactory.CreateRupee(position);
            }
            if (name == "Rupee")
            {
                return itemFactory.Create1Rupee(position);
            }
            if (name == "Heart")
            {
                return itemFactory.CreateHeart(position);
            }
            if (name == "Fairy")
            {
                return itemFactory.CreateFairy(position);
            }
            if (name == "Watch")
            {
                return itemFactory.CreateWatch(position);
            }
            if (name == "Bow")
            {
                return itemFactory.CreateBow(position);
            }
            if (name == "Arrow")
            {
                return itemFactory.CreateArrow(position);
            }
            if (name == "Key")
            {
                return itemFactory.CreateKey(position);
            }
            if (name == "Sword")
            {
                return itemFactory.CreateSword(position);
            }
            if (name == "Map")
            {
                return itemFactory.CreateMap(position);
            }
            if (name == "Triforce")
            {
                return itemFactory.CreateTriforce(position);
            }
            if (name == "Ring")
            {
                return itemFactory.CreateRing(position);
            }
            if (name == "Compass")
            {
                return itemFactory.CreateCompass(position);
            }
            throw new Exception($"The object {name} has not been mapped in ObjectLookup yet!");
        }

        public IGameObject CreateEnemyObject(string name, Vector2 position)
        {
            if(name=="AquaGel")
            {
                return enemyFactory.CreateAquaGel(position);
            }
            if (name == "BlackGel")
            {
                return enemyFactory.CreateBlackGel(position);
            }
            if (name == "RedGoriya")
            {
                return enemyFactory.CreateRedGoriya(position);
            }
            if (name == "BlueGoriya")
            {
                return enemyFactory.CreateBlueGoriya(position);
            }
            if (name == "BlueKeese")
            {
                return enemyFactory.CreateBlueKeese(position);
            }
            if (name == "RedKeese")
            {
                return enemyFactory.CreateRedKeese(position);
            }
            if (name == "Stalfos")
            {
                return enemyFactory.CreateStalfos(position);
            }
            if (name == "Wallmaster")
            {
                return enemyFactory.CreateWallmaster(position);
            }
            if (name == "GreenZol")
            {
                return enemyFactory.CreateGreenZol(position);
            }
            if (name == "GrayZol")
            {
                return enemyFactory.CreateGrayZol(position);
            }
            if (name == "Rope")
            {
                return enemyFactory.CreateRope(position);
            }
            if (name == "Dongo")
            {
                return enemyFactory.CreateDongo(position);
            }
            if (name == "Aquamentus")
            {
                return enemyFactory.CreateAquamentus(position);
            }
            if (name == "BulletHell")
            {
                return enemyFactory.CreateBulletHellAquamentus(position);
            }
            if (name == "Flame")
            {
                return enemyFactory.CreateFlame(position);
            }
            if (name == "OldMan")
            {
                return enemyFactory.CreateOldMan(position);
            }
            if (name == "GreenMerchant")
            {
                return enemyFactory.CreateGreenMerchant(position);
            }
            throw new Exception($"The object {name} has not been mapped in ObjectLookup yet!");
        }
    }
}

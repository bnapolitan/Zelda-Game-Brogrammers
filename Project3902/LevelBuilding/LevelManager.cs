using Microsoft.Xna.Framework;
using Project3902.GameObjects;
using Project3902.GameObjects.Environment;
using Project3902.ObjectManagement;
using System;
using System.Collections.Generic;

namespace Project3902.LevelBuilding
{
    class LevelManager
    {
        public readonly Dictionary<String, Level> levelDict=new Dictionary<string, Level>();
        public static LevelManager Instance { get; } = new LevelManager();
        private Level current;
        private String currentString;
        private Boolean Room2KeyAdded = false;
        private Boolean Room3KeyAdded = false;
        private Boolean Room6DoorReleased = false;
        private Boolean Room8DoorReleased = false;
        private Boolean Room16DoorReleased = false;
        private int waves=0;
        private Boolean SurvivalDoorReleased = false;
        private LevelManager()
        {

        }

        public Level GetLevel(String levelName)
        {

            Level currentLevel= levelDict[levelName];
            CollisionHandler.Instance.Flush();
            CollisionHandler.Instance.CheckCollisions();
            foreach (IEnemy enemy in currentLevel.enemyObjects)
            {
                if (enemy is Flame)
                {
                    CollisionHandler.Instance.RegisterCollidable(enemy, Layer.Enemy, Layer.Wall);
                }
                else
                {
                    CollisionHandler.Instance.RegisterCollidable(enemy, Layer.Enemy, Layer.Wall, Layer.Projectile);
                }
            }
            foreach (IItem item in currentLevel.itemObjects)
            {
                if (item is Bomb)
                {
                    CollisionHandler.Instance.RegisterCollidable(item, Layer.Projectile, Layer.Enemy, Layer.Wall);
                }
                else
                {
                    CollisionHandler.Instance.RegisterCollidable(item, Layer.Pickup);
                }
            }
            foreach (IGameObject environment in currentLevel.interactiveEnvironmentObjects)
            {
                if(environment is ExplodableWall)
                {
                    CollisionHandler.Instance.RegisterCollidable((environment as ICollidable), Layer.Wall, Layer.Projectile);
                }
                else if(environment is ICollidable)
                {
                    CollisionHandler.Instance.RegisterCollidable((environment as ICollidable), Layer.Wall);
                }
            }
            current = currentLevel;
            currentString = levelName;
            return currentLevel;
        }

        public Level GetLevelWithOffset(String levelName, Vector2 offset)
        {

            Level currentLevel = levelDict[levelName];
            CollisionHandler.Instance.Flush();
            foreach (IEnemy enemy in currentLevel.enemyObjects)
            {
                enemy.Position += offset;
                if(enemy is Flame)
                {
                    CollisionHandler.Instance.RegisterCollidable(enemy, Layer.Enemy, Layer.Wall);
                }
                else
                {
                    CollisionHandler.Instance.RegisterCollidable(enemy, Layer.Enemy, Layer.Wall, Layer.Projectile);
                }
            }
            foreach (IItem item in currentLevel.itemObjects)
            {
                item.Position += offset;
                CollisionHandler.Instance.RegisterCollidable(item, Layer.Pickup);
            }
            foreach (IGameObject environment in currentLevel.interactiveEnvironmentObjects)
            {
                environment.Position += offset;
                if (environment is ICollidable)
                {
                    CollisionHandler.Instance.RegisterCollidable((environment as ICollidable), Layer.Wall);
                }
            }
            current = currentLevel;
            currentString = levelName;
            return currentLevel;
        }

        public void AddObjectToCurrentLevel(IGameObject gameObject)
        {
            if (gameObject is IEnemy)
            {
                current.enemyObjects.Add(gameObject);
            }
            else if (gameObject is IItem)
            {
                current.itemObjects.Add(gameObject);
            }
            else if (gameObject is IInteractiveEnvironmentObject)
            {
                current.interactiveEnvironmentObjects.Add(gameObject);
            }
        }

        public void RemoveObjectFromCurrentLevel(IGameObject gameObject)
        {
            if(gameObject is IEnemy)
            {
                current.enemyObjects.Remove(gameObject);
            }
            else if(gameObject is IItem)
            {
                current.itemObjects.Remove(gameObject);
            }
            else if(gameObject is IInteractiveEnvironmentObject)
            {
                current.itemObjects.Remove(gameObject);
            }
        }
        public void ResetLevels()
        {
            if (levelDict != null)
                levelDict.Clear();
            GenerateLevels();
        }

        private void GenerateLevels()
        {
            levelDict.Add("DungeonRoom0", new Level("DungeonRoom0"));
            levelDict.Add("DungeonRoom1", new Level("DungeonRoom1"));
            levelDict.Add("DungeonRoom2", new Level("DungeonRoom2"));
            levelDict.Add("DungeonRoom3", new Level("DungeonRoom3"));
            levelDict.Add("DungeonRoom4", new Level("DungeonRoom4"));
            levelDict.Add("DungeonRoom5", new Level("DungeonRoom5"));
            levelDict.Add("DungeonRoom6", new Level("DungeonRoom6"));
            levelDict.Add("DungeonRoom7", new Level("DungeonRoom7"));
            levelDict.Add("DungeonRoom8", new Level("DungeonRoom8"));
            levelDict.Add("DungeonRoom9", new Level("DungeonRoom9"));
            levelDict.Add("DungeonRoom10", new Level("DungeonRoom10"));
            levelDict.Add("DungeonRoom11", new Level("DungeonRoom11"));
            levelDict.Add("DungeonRoom12", new Level("DungeonRoom12"));
            levelDict.Add("DungeonRoom13", new Level("DungeonRoom13"));
            levelDict.Add("DungeonRoom14", new Level("DungeonRoom14"));
            levelDict.Add("DungeonRoom15", new Level("DungeonRoom15"));
            levelDict.Add("DungeonRoom16", new Level("DungeonRoom16"));
            levelDict.Add("DungeonRoom17", new Level("DungeonRoom17"));
            levelDict.Add("BulletHellRoom", new Level("BulletHellRoom"));
            levelDict.Add("SurvivalRoom", new Level("SurvivalRoom"));
            Room2KeyAdded = false;
            Room3KeyAdded = false;
            Room6DoorReleased = false;
            Room8DoorReleased = false;
            Room16DoorReleased = false;
            SurvivalDoorReleased = false;
            waves = 0;
        }

        public void CheckSpecials()
        {
            switch (currentString)
            {
                case "DungeonRoom2":
                    if (!Room2KeyAdded && current.enemyObjects.Count == 0)
                    {
                        AddObjectToCurrentLevel(ItemFactory.Instance.CreateKey(new Vector2(750, 400 + HUDFactory.Instance.HUDHeight)));
                        Room2KeyAdded = true;
                    }
                    break;
                case "DungeonRoom3":
                    if (!Room3KeyAdded && current.enemyObjects.Count == 0)
                    {
                        AddObjectToCurrentLevel(ItemFactory.Instance.CreateKey(new Vector2(832, 512 + HUDFactory.Instance.HUDHeight)));
                        Room3KeyAdded = true;
                    }
                    break;
                case "DungeonRoom6":
                    if (!Room6DoorReleased && current.enemyObjects.Count == 0)
                    {

                        foreach (var environment in current.interactiveEnvironmentObjects)
                        {
                            if (environment is ShutDoor)
                            {
                                CollisionHandler.Instance.RemoveCollidable(environment as ICollidable);
                            }
                        }
                        current.interactiveEnvironmentObjects.RemoveAll(i => i is ShutDoor);
                        SoundHandler.Instance.PlaySoundEffect("Door Unlock");
                        AddObjectToCurrentLevel(EnvironmentFactory.Instance.CreateOpenDoorRight(new Vector2(896, 288 + HUDFactory.Instance.HUDHeight)));
                        Room6DoorReleased = true;
                    }
                    break;
                case "DungeonRoom8":
                    if (!Room8DoorReleased)
                    {
                        Boolean moved = false;
                        foreach (var environment in current.interactiveEnvironmentObjects)
                        {
                            if (environment is MoveableBlock)
                            {
                                if (environment.Position.X <=385 && environment.Position.Y>= 317 + HUDFactory.Instance.HUDHeight)
                                {

                                    CollisionHandler.Instance.RemoveCollidable(environment as ICollidable);
                                    SoundHandler.Instance.PlaySoundEffect("Secret");
                                    moved = true;
                                }

                            }
                        }
                        if (moved)
                        {
                            foreach (var environment in current.interactiveEnvironmentObjects)
                            {
                                if (environment is ShutDoor)
                                {
                                    CollisionHandler.Instance.RemoveCollidable(environment as ICollidable);
                                }
                            }
                            current.interactiveEnvironmentObjects.RemoveAll(i => i is ShutDoor);
                            SoundHandler.Instance.PlaySoundEffect("Door Unlock");
                            AddObjectToCurrentLevel(EnvironmentFactory.Instance.CreateOpenDoorLeft(new Vector2(0, 288 + HUDFactory.Instance.HUDHeight)));
                            Room8DoorReleased = true;
                        }
                    }
                    break;
                case "DungeonRoom16":
                    if (!Room16DoorReleased && current.enemyObjects.Count == 0)
                    {

                        foreach (var environment in current.interactiveEnvironmentObjects)
                        {
                            if (environment is ShutDoor)
                            {
                                CollisionHandler.Instance.RemoveCollidable(environment as ICollidable);
                            }
                        }
                        current.interactiveEnvironmentObjects.RemoveAll(i => i is ShutDoor);
                        SoundHandler.Instance.PlaySoundEffect("Door Unlock");
                        AddObjectToCurrentLevel(EnvironmentFactory.Instance.CreateOpenDoorRight(new Vector2(896, 288 + HUDFactory.Instance.HUDHeight)));
                        AddObjectToCurrentLevel(ItemFactory.Instance.CreateHeartContainer(new Vector2(832, 320+ HUDFactory.Instance.HUDHeight)));
                        Room16DoorReleased = true;
                    }
                    break;
                case "SurvivalRoom":
                    if (!SurvivalDoorReleased && current.enemyObjects.Count == 0)
                    {
                        waves++;
                        if (waves == 5)
                        {
                            foreach (var environment in current.interactiveEnvironmentObjects)
                            {
                                if (environment is ShutDoor)
                                {
                                    CollisionHandler.Instance.RemoveCollidable(environment as ICollidable);
                                }
                            }
                            current.interactiveEnvironmentObjects.RemoveAll(i => i is ShutDoor);
                            SoundHandler.Instance.PlaySoundEffect("Door Unlock");
                            AddObjectToCurrentLevel(EnvironmentFactory.Instance.CreateOpenDoorRight(new Vector2(896, 288 + HUDFactory.Instance.HUDHeight)));
                            AddObjectToCurrentLevel(ItemFactory.Instance.CreateHeartContainer(new Vector2(480, 320 + HUDFactory.Instance.HUDHeight)));
                            SurvivalDoorReleased = true;
                        }
                        else
                        {
                            Random r = new Random();
                            int num = r.Next(1, 5);
                            for(int i = 0; i < num; i++)
                            {
                                int x = r.Next(128, 832);
                                int y = r.Next(128, 512);
                                Vector2 position = new Vector2(x, y+HUDFactory.Instance.HUDHeight);
                                int enemyType = r.Next(0, 8);
                                switch (enemyType)
                                {
                                    case 0:
                                        AddObjectToCurrentLevel(EnemyFactory.Instance.CreateAquamentus(position));
                                        break;
                                    case 1:
                                        AddObjectToCurrentLevel(EnemyFactory.Instance.CreateAquaGel(position));
                                        break;
                                    case 2:
                                        AddObjectToCurrentLevel(EnemyFactory.Instance.CreateRedGoriya(position));
                                        break;
                                    case 3:
                                        AddObjectToCurrentLevel(EnemyFactory.Instance.CreateBlueKeese(position));
                                        break;
                                    case 4:
                                        AddObjectToCurrentLevel(EnemyFactory.Instance.CreateRope(position));
                                        break;
                                    case 5:
                                        AddObjectToCurrentLevel(EnemyFactory.Instance.CreateStalfos(position));
                                        break;
                                    case 6:
                                        AddObjectToCurrentLevel(EnemyFactory.Instance.CreateWallmaster(position));
                                        break;
                                    case 7:
                                        AddObjectToCurrentLevel(EnemyFactory.Instance.CreateGrayZol(position));
                                        break;
                                }

                            }
                        }

                    }
                    break;
            }
        }
    }
}

using Microsoft.Xna.Framework;
using Project3902.GameObjects;
using System;
using System.Collections.Generic;

namespace Project3902.LevelBuilding
{
    class LevelManager
    {
        readonly Dictionary<String, Level> levelDict=new Dictionary<string, Level>();
        public static LevelManager Instance { get; } = new LevelManager();

        private LevelManager()
        {
            
        }

        public Level GetLevel(String levelName)
        {

            Level currentLevel= levelDict[levelName];
            CollisionHandler.Instance.Flush();
            Console.WriteLine("After Flush");
            CollisionHandler.Instance.CheckCollisions();
            foreach (IEnemy enemy in currentLevel.enemyObjects)
            {
                CollisionHandler.Instance.RegisterCollidable(enemy, Layer.Enemy, Layer.Wall, Layer.Projectile);
            }
            Console.WriteLine("After Enemies");
            foreach (IItem item in currentLevel.itemObjects)
            {
                CollisionHandler.Instance.RegisterCollidable(item, Layer.Pickup);
            }
            Console.WriteLine("After Items");
            foreach (IGameObject environment in currentLevel.interactiveEnvironmentObjects)
            {
                if(environment is ICollidable)
                {
                    CollisionHandler.Instance.RegisterCollidable((environment as ICollidable), Layer.Wall);
                }
            }
            Console.WriteLine("After Environment");
            return currentLevel;
        }

        public Level GetLevelWithOffset(String levelName, Vector2 offset)
        {

            Level currentLevel = levelDict[levelName];
            CollisionHandler.Instance.Flush();
            //CollisionHandler.Instance.CheckCollisions();
            foreach (IEnemy enemy in currentLevel.enemyObjects)
            {
                enemy.Position += offset;
                CollisionHandler.Instance.RegisterCollidable(enemy, Layer.Enemy, Layer.Wall, Layer.Projectile);
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
            return currentLevel;
        }

        public void ResetLevels()
        {
            if (levelDict != null)
                levelDict.Clear();
            Console.WriteLine("Before Generate");
            GenerateLevels();
            Console.WriteLine("After Generate");
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
        }
    }
}

﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.Configuration;
using System.Collections.Generic;

namespace Project3902.LevelBuilding
{
    class Level : ILevel
    {
        public string LevelName { get; set; }
        public LevelMap Map { get; set; }
        public Vector2 ScrollDirection { get; set; }
        public bool Scrolling { get; set; } = false;
        public float ScrollSpeed { get; set; } = GeneralGameConfiguration.ScreenScrollSpeed;

        private int freezeTime = 0;

        public List<IGameObject> interactiveEnvironmentObjects;
        public List<IGameObject> enemyObjects;
        public List<IGameObject> itemObjects;

        private readonly LevelBuilder builder;

        public Level(string name)
        {
            builder = new LevelBuilder(name);
            this.LevelName = name;

            LoadLevel();
        }

        public Level(string name, Vector2 offset)
        {
            builder = new LevelBuilder(name);

            LoadLevel();

            OffsetGameObjects(offset);
        }

        public void LoadLevel()
        {
            interactiveEnvironmentObjects = builder.CreateInteractiveEnvironmentObjects();

            itemObjects = builder.CreateItemObjects();

            enemyObjects = builder.CreateEnemyObjects();

            Map = builder.CreateAdjacentLevels();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IGameObject gameObject in interactiveEnvironmentObjects)
            {
                gameObject.Draw(spriteBatch);
            }

            if (Scrolling)
                return;

            foreach (IGameObject gameObject in itemObjects)
            {
                gameObject.Draw(spriteBatch);
            }

            foreach (IGameObject gameObject in enemyObjects)
            {
                gameObject.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (Scrolling)
            {
                ScrollGameObjects();
                return;
            }

            foreach (IGameObject gameObject in interactiveEnvironmentObjects)
            {
                gameObject.Update(gameTime);
            }

            foreach (IGameObject gameObject in enemyObjects)
            {
                gameObject.Update(gameTime);
            }

            foreach (IGameObject gameObject in itemObjects)
            {
                gameObject.Update(gameTime);
            }

            if(this.freezeTime > 0)
            {
                if(this.freezeTime == 1)
                {
                    this.UnFreezeEnemies();
                }
                this.freezeTime--;
            }
        }

        public void FreezeEnemies()
        {
            freezeTime = GeneralGameConfiguration.EnemyFreezeTime;
            foreach (BaseEnemy gameObject in enemyObjects)
            {
                gameObject.Freeze();
            }
        }

        public void UnFreezeEnemies()
        {
            foreach (BaseEnemy gameObject in enemyObjects)
            {
                gameObject.UnFreeze();
            }
        }

        private void ScrollGameObjects()
        {
            foreach (IGameObject gameObject in interactiveEnvironmentObjects)
            {
                gameObject.Position += ScrollDirection * ScrollSpeed;
            }

            foreach (IGameObject gameObject in enemyObjects)
            {
                gameObject.Position += ScrollDirection * ScrollSpeed;
            }

            foreach (IGameObject gameObject in itemObjects)
            {
                gameObject.Position += ScrollDirection * ScrollSpeed;
            }
        }

        public void OffsetGameObjects(Vector2 offset)
        {
            foreach (IGameObject gameObject in interactiveEnvironmentObjects)
            {
                gameObject.Position += offset;
            }

            foreach (IGameObject gameObject in enemyObjects)
            {
                gameObject.Position += offset;
            }

            foreach (IGameObject gameObject in itemObjects)
            {
                gameObject.Position += offset;
            }
        }
    }
}

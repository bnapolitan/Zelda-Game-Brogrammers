﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project3902.LevelBuilding
{
    class Level : ILevel
    {
        public string LevelName { get; set; }
        public LevelMap Map { get; set; }
        public Vector2 ScrollDirection { get; set; }
        public bool Scrolling { get; set; } = false;
        public float ScrollSpeed { get; set; } = 400;

        private List<IGameObject> interactiveEnvironmentObjects;
        private List<IGameObject> enemyObjects;
        private List<IGameObject> itemObjects;

        private readonly LevelBuilder builder;
        
        public Level(string name)
        {
            builder = new LevelBuilder(name);

            LoadLevel();
        }

        public Level(string name, Vector2 offset)
        {
            builder = new LevelBuilder(name);

            LoadLevel();

            PositionGameObjects(offset);
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
                ScrollGameObjects(gameTime);
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
        }

        private void ScrollGameObjects(GameTime gameTime)
        {
            var elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (IGameObject gameObject in interactiveEnvironmentObjects)
            {
                gameObject.Position += ScrollDirection * ScrollSpeed * elapsed;
            }

            foreach (IGameObject gameObject in enemyObjects)
            {
                gameObject.Position += ScrollDirection * ScrollSpeed * elapsed;
            }

            foreach (IGameObject gameObject in itemObjects)
            {
                gameObject.Position += ScrollDirection * ScrollSpeed * elapsed;
            }
        }

        public void PositionGameObjects(Vector2 offset)
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

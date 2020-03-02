﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.ObjectManagement;
using System.Collections.Generic;

/* 
 * Team:
 * Dan Bellini
 * Huang Huang
 * Xueyang Li
 * Ben Napolitan
 * Austin Rogers
 * Suraj Suresh
*/

namespace Project3902
{
    class FinalGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public ILink Link { get; set; }

        public List<IGameObject> interactiveEnvironmentObjects;

        List<IGameObject> enemyObjects;
        List<IGameObject> itemObjects;
        int currentItem;

        IController<MouseActions> mouseController;
        KeyboardController keyboardController;

        public FinalGame()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }

        public static class currentFram
        {
            private static int cur = 0;

            public static int Current
            {
                get { return cur; }
                set { cur = value; }

            }
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 672;
            graphics.ApplyChanges();

            SetUpMouseController();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var level = new LevelBuilder(this, "DungeonRoom2");

            LinkFactory.Instance.LoadAllTextures(Content);
            Link = LinkFactory.Instance.CreateLink(new Vector2(100, 100), this);
            CollisionHandler.Instance.RegisterCollidable(Link, Layer.Player, Layer.Enemy, Layer.Wall, Layer.Pickup);

            keyboardController = LinkFactory.Instance.CreateLinkController(Link);

            ShapeSpriteFactory.Instance.CreateShapeTextures(GraphicsDevice);

            WeaponFactory.Instance.LoadAllTextures(Content);

            EnvironmentFactory.Instance.LoadAllTextures(Content);
            interactiveEnvironmentObjects = level.CreateInteractiveEnvironmentObjects();

            EnemyFactory.Instance.LoadAllTextures(Content);
            enemyObjects = level.CreateEnemyObjects();
            ItemFactory.Instance.LoadAllTextures(Content);
            itemObjects = new Sprint2Level(this).CreateItem();
            currentItem = 0;
        }


        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            mouseController.Update();
            keyboardController.Update();
            itemObjects[currentItem].Update(gameTime);

            foreach (IGameObject gameObject in interactiveEnvironmentObjects)
            {
                gameObject.Update(gameTime);
            }

            foreach (IGameObject gameObject in enemyObjects)
            {
                gameObject.Update(gameTime);
            }

            base.Update(gameTime);

            Link.Update(gameTime);

            CollisionHandler.Instance.CheckCollisions();
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            foreach(IGameObject gameObject in interactiveEnvironmentObjects)
            {
                gameObject.Draw(spriteBatch);
            }

            foreach (IGameObject gameObject in enemyObjects)
            {
                gameObject.Draw(spriteBatch);
            }


            itemObjects[currentItem].Draw(spriteBatch);

            Link.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void SetUpMouseController()
        {
            mouseController = new MouseController();

            //Fill with functionality later
        }

        public void CycleItemNext()
        {
            currentItem = (currentItem + 1) % itemObjects.Count;
        }

        public void CycleItemLast()
        {
            if (currentItem == 0)
            {
                currentItem = itemObjects.Count - 1;
            }
            else
            {
                currentItem--;
            }

        }

    }
}

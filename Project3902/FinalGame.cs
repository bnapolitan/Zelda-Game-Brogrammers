﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project3902.GameObjects;
using Project3902.ObjectManagement;
using Project3902.Commands.Sprint2Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project3902.GameObjects.Enemies_and_NPCs.Interfaces;
using Microsoft.Xna.Framework.Input;

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
        //RenderTarget2D renderTarget;
        //Rectangle actualScreenRect;

        public ILink Link { get; set; }

        public List<IGameObject> interactiveEnvironmentObjects;

        List<IGameObject> enemyObjects;

        IController<MouseActions> mouseController;
        KeyboardController keyboardController;

        public FinalGame()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 672;
            graphics.ApplyChanges();

            // Set up controllers.
            SetUpMouseController();
            //SetUpKeyboardController();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var level = new DungeonRoom1(this);

            // Create player.
            LinkFactory.Instance.LoadAllTextures(Content);
            Link = LinkFactory.Instance.CreateLink(new Vector2(100, 100), this);

            WeaponFactory.Instance.LoadAllTextures(Content);

            // Create list of all items to be cycled through. Use a Factory class to create them.
            // Same for enemies.

            // Create environment.
            EnvironmentFactory.Instance.LoadAllTextures(Content);
            interactiveEnvironmentObjects = level.CreateInteractiveEnvironmentObjects();

            //Create Enemies
            EnemyFactory.Instance.LoadAllTextures(Content);
            enemyObjects = level.CreateEnemyObjects();
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            mouseController.Update();
            //keyboardController.Update();

            //Environment
            foreach (IGameObject gameObject in enemyObjects)
            {
                gameObject.Update(gameTime);
            }

            //Enemies
            foreach (IGameObject gameObject in enemyObjects)
            {
                gameObject.Update(gameTime);
            }

            base.Update(gameTime);

            Link.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.SetRenderTarget(renderTarget);

            GraphicsDevice.Clear(Color.Black);

            // Point filter keeps pixel art looking crisp.
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // All our drawing code goes here.

            // An IDrawable's Draw() method does not call spriteBatch.Begin() or spriteBatch.End().
            //Environment
            foreach(IGameObject gameObject in interactiveEnvironmentObjects)
            {
                gameObject.Draw(spriteBatch);
            }

            //Enemies
            foreach (IGameObject gameObject in enemyObjects)
            {
                gameObject.Draw(spriteBatch);
            }

            // Player
            Link.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void SetUpMouseController()
        {
            mouseController = new MouseController();

            //Fill with functionality later
        }

        private void SetUpKeyboardController()
        {
            keyboardController = new KeyboardController();

            //No current keys needed besides Link actions
        }
    }
}
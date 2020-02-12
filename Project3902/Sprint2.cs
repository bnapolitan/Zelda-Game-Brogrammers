﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project3902.GameObjects;
using Project3902.ObjectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    class Sprint2 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //RenderTarget2D renderTarget;
        //Rectangle actualScreenRect;

        public ILink Link { get; set; }

        List<IGameObject> interactiveEnvironmentObjects;
        int currentInteractiveEnvironmentObject;

        IController<MouseActions> mouseController;

        private bool OKeyDown = false;

        public Sprint2()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.PreferredBackBufferWidth = 256 * 3;
            //graphics.PreferredBackBufferHeight = 176 * 3;

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            // Set up controllers.
            SetUpMouseController();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            //renderTarget = new RenderTarget2D(GraphicsDevice, 256, 176);
            //actualScreenRect = new Rectangle(0, 0, GraphicsDeviceManager.DefaultBackBufferWidth, GraphicsDeviceManager.DefaultBackBufferHeight);

            var level = new Sprint2Level();

            // Create player.
            LinkFactory.Instance.LoadAllTextures(Content);
            WeaponFactory.Instance.LoadAllTextures(Content);
            Link = LinkFactory.Instance.CreateLink(new Vector2(100, 100), this);

            // Create list of all items to be cycled through. Use a Factory class to create them.
            // Same for enemies.

            // Create environment.
            EnvironmentFactory.Instance.LoadAllTextures(Content);
            interactiveEnvironmentObjects = level.CreateInteractiveEnvironmentObjects();
            currentInteractiveEnvironmentObject = 0;
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.O) && !OKeyDown)
            {
                OKeyDown = true;
                // Cycle enemies
            }
            if (state.IsKeyUp(Keys.O))
            {
                OKeyDown = false;
            }

            mouseController.Update();

            Link.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.SetRenderTarget(renderTarget);

            GraphicsDevice.Clear(Color.Black);

            // Point filter keeps pixel art looking crisp.
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // All our drawing code goes here.

            // Player
            Link.Draw(spriteBatch);

            // An IDrawable's Draw() method does not call spriteBatch.Begin() or spriteBatch.End().

            //Environment
            interactiveEnvironmentObjects[currentInteractiveEnvironmentObject].Draw(spriteBatch);

            spriteBatch.End();

            //GraphicsDevice.SetRenderTarget(null);

            //spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            //spriteBatch.Draw(renderTarget, actualScreenRect, null, Color.White);
            //spriteBatch.End();

            base.Draw(gameTime);
        }

        private void SetUpMouseController()
        {
            mouseController = new MouseController();

            mouseController.RegisterCommand(MouseActions.Left, new CycleNextEnvironmentObjectCommand(this));
            mouseController.RegisterCommand(MouseActions.Right, new CycleLastEnvironmentObjectCommand(this));
        }

        public void CycleEnvironmentNext()
        {
            currentInteractiveEnvironmentObject = (currentInteractiveEnvironmentObject + 1) % interactiveEnvironmentObjects.Count;
        }

        public void CycleEnvironmentLast()
        {
            if (currentInteractiveEnvironmentObject == 0)
            {
                currentInteractiveEnvironmentObject = interactiveEnvironmentObjects.Count - 1;
            }
            else
            {
                currentInteractiveEnvironmentObject--;
            }
        }
    }
}
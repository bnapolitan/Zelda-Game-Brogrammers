using Microsoft.Xna.Framework;
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
    class Sprint2 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //RenderTarget2D renderTarget;
        //Rectangle actualScreenRect;

        public ILink Link { get; set; }

        List<IGameObject> interactiveEnvironmentObjects;
        int currentInteractiveEnvironmentObject;

        List<IGameObject> enemyObjects;
        int currentEnemyObject;

        IController<MouseActions> mouseController;
        KeyboardController keyboardController;

        private bool OKeyDown = false;
        private bool PKeyDown = false;

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
            //SetUpKeyboardController();

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
            Link = LinkFactory.Instance.CreateLink(new Vector2(100, 100), this);

            // Create list of all items to be cycled through. Use a Factory class to create them.
            // Same for enemies.

            // Create environment.
            EnvironmentFactory.Instance.LoadAllTextures(Content);
            interactiveEnvironmentObjects = level.CreateInteractiveEnvironmentObjects();
            currentInteractiveEnvironmentObject = 0;
            EnemyFactory.Instance.LoadAllTextures(Content);
            enemyObjects = level.CreateEnemyObjects();
            currentEnemyObject = 0;
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            mouseController.Update();
            //keyboardController.Update();
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.O)&&!OKeyDown){
                OKeyDown = true;
                CycleEnemyLast();
            }
            if (state.IsKeyUp(Keys.O))
            {
                OKeyDown = false;
            }
            if (state.IsKeyDown(Keys.P)&&!PKeyDown)
            {
                PKeyDown = true;
                CycleEnemyNext();
            }
            if (state.IsKeyUp(Keys.P))
            {
                PKeyDown = false;
            }
            enemyObjects[currentEnemyObject].Update(gameTime);

            //Environment
            interactiveEnvironmentObjects[currentInteractiveEnvironmentObject].Update(gameTime);

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

            // Player
            Link.Draw(spriteBatch);

            // An IDrawable's Draw() method does not call spriteBatch.Begin() or spriteBatch.End().
            //Environment
            enemyObjects[currentEnemyObject].Draw(spriteBatch);

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

        private void SetUpKeyboardController()
        {
            keyboardController = new KeyboardController();

            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.P, new CycleNextEnemyObjectCommand(this));
            keyboardController.RegisterCommand(Microsoft.Xna.Framework.Input.Keys.O, new CycleLastEnemyObjectCommand(this));
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
        public void CycleEnemyNext()
        {
            currentEnemyObject = (currentEnemyObject + 1) % enemyObjects.Count;
        }

        public void CycleEnemyLast()
        {
            if (currentEnemyObject == 0)
            {
                currentEnemyObject = enemyObjects.Count - 1;
            }
            else
            {
                currentEnemyObject--;
            }

        }
    }
}

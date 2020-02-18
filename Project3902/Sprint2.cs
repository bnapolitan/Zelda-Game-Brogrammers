using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project3902.Commands.Sprint2Commands;
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
    class Sprint2 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private ItemSprite Items;
        //RenderTarget2D renderTarget;
        //Rectangle actualScreenRect;

        public ILink Link { get; set; }

        List<IGameObject> interactiveEnvironmentObjects;
        int currentInteractiveEnvironmentObject;

        List<IGameObject> enemyObjects;
        int currentEnemyObject;

        IController<MouseActions> mouseController;
        KeyboardController keyboardController;

        public Sprint2()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.PreferredBackBufferWidth = 256 * 3;
            //graphics.PreferredBackBufferHeight = 176 * 3;

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

            // Set up controllers.
            SetUpMouseController();
            SetUpKeyboardController();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //renderTarget = new RenderTarget2D(GraphicsDevice, 256, 176);
            //actualScreenRect = new Rectangle(0, 0, GraphicsDeviceManager.DefaultBackBufferWidth, GraphicsDeviceManager.DefaultBackBufferHeight);

            var level = new Sprint2Level(this);

            // Create player.
            LinkFactory.Instance.LoadAllTextures(Content);
            Link = LinkFactory.Instance.CreateLink(new Vector2(100, 100), this);
            Items = new FixedItem(Content.Load<Texture2D>("Items"), 1, 14);

            WeaponFactory.Instance.LoadAllTextures(Content);

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
            keyboardController.Update();

            enemyObjects[currentEnemyObject].Update(gameTime);
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

            //Item
            Vector2 ItPosition = new Vector2(150,300);
            Items.Draw(spriteBatch, ItPosition);


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


        //Item control
        public void items()
        {
            this.Items = new FixedItem(Content.Load<Texture2D>("Luigi/Zelda"), 1, 14);
        }

        public void cycNxtItm()
        {
            Sprint2.currentFram.Current++;
            this.Items = new FixedItem(Content.Load<Texture2D>("Items"), 1, 14);
        }

        public void cycPrvItm()
        {
            Sprint2.currentFram.Current--;
            this.Items = new FixedItem(Content.Load<Texture2D>("Items"), 1, 14);
        }

        private void SetUpMouseController()
        {
            mouseController = new MouseController();

            mouseController.RegisterCommand(MouseActions.Left, new CycleNextEnvironmentObjectCommand(this), InputState.Pressed);
            mouseController.RegisterCommand(MouseActions.Right, new CycleLastEnvironmentObjectCommand(this), InputState.Pressed);
        }

        private void SetUpKeyboardController()
        {
            keyboardController = new KeyboardController();

            keyboardController.RegisterCommand(Keys.P, new CycleNextEnemyObjectCommand(this), InputState.Pressed);
            keyboardController.RegisterCommand(Keys.O, new CycleLastEnemyObjectCommand(this), InputState.Pressed);
            keyboardController.RegisterCommand(Keys.I, new CycNxtItm(this), InputState.Pressed);
            keyboardController.RegisterCommand(Keys.U, new CycPrvItm(this), InputState.Pressed);
            keyboardController.RegisterCommand(Keys.Q, new ExitGameCommand(this));
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
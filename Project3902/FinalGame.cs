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
    class FinalGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private ItemSprite Items;

        public ILink Link { get; set; }

        List<IGameObject> interactiveEnvironmentObjects;
        int currentInteractiveEnvironmentObject;

        List<IGameObject> enemyObjects;
        int currentEnemyObject;

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

            SetUpMouseController();
            SetUpKeyboardController();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var level = new Sprint2Level(this);

            LinkFactory.Instance.LoadAllTextures(Content);
            Link = LinkFactory.Instance.CreateLink(new Vector2(100, 100), this);
            CollisionHandler.Instance.RegisterCollidable(Link, Layer.Player, Layer.Enemy, Layer.Wall, Layer.Pickup);

            ShapeSpriteFactory.Instance.CreateShapeTextures(GraphicsDevice);

            Items = new FixedItem(Content.Load<Texture2D>("Items"), 1, 14);

            WeaponFactory.Instance.LoadAllTextures(Content);

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

            CollisionHandler.Instance.CheckCollisions();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            Link.Draw(spriteBatch);

            Vector2 ItPosition = new Vector2(150,300);
            Items.Draw(spriteBatch, ItPosition);

            enemyObjects[currentEnemyObject].Draw(spriteBatch);

            interactiveEnvironmentObjects[currentInteractiveEnvironmentObject].Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }


        public void items()
        {
            this.Items = new FixedItem(Content.Load<Texture2D>("Luigi/Zelda"), 1, 14);
        }

        public void cycNxtItm()
        {
            FinalGame.currentFram.Current++;
            this.Items = new FixedItem(Content.Load<Texture2D>("Items"), 1, 14);
        }

        public void cycPrvItm()
        {
            FinalGame.currentFram.Current--;
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
using Microsoft.Xna.Framework;
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
        readonly GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public ILink Link { get; set; }

        public List<IGameObject> interactiveEnvironmentObjects;

        public List<IGameObject> enemyObjects;
        public List<IGameObject> itemObjects;

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

            SetUpMouseController();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            var level = new LevelBuilder(this, "DungeonRoom1");

            LinkFactory.Instance.LoadAllTextures(Content);
            Link = LinkFactory.Instance.CreateLink(new Vector2(256, 256), this);
            CollisionHandler.Instance.RegisterCollidable(Link, Layer.Player, Layer.Enemy, Layer.Wall, Layer.Pickup, Layer.Projectile);

            keyboardController = LinkFactory.Instance.CreateLinkController(this);

            ShapeSpriteFactory.Instance.CreateShapeTextures(GraphicsDevice);

            WeaponFactory.Instance.LoadAllTextures(Content);

            EnvironmentFactory.Instance.LoadAllTextures(Content);
            interactiveEnvironmentObjects = level.CreateInteractiveEnvironmentObjects();

            ItemFactory.Instance.LoadAllTextures(Content);
            itemObjects = level.CreateItemObjects();

            EnemyFactory.Instance.RegisterGame(this);
            EnemyFactory.Instance.LoadAllTextures(Content);
            enemyObjects = level.CreateEnemyObjects();

            CollisionHandler.Instance.RegisterGame(this);
        }


        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            mouseController.Update();
            keyboardController.Update();

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

            foreach (IGameObject gameObject in itemObjects)
            {
                gameObject.Draw(spriteBatch);
            }



            Link.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void SetUpMouseController()
        {
            mouseController = new MouseController();

     
        }

    }
}

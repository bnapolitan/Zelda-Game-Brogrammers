using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

// Author: Austin Rogers.1274
// Date: 1/17/2020

namespace Sprint0
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Sprint0 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private IController<Keys> keyboardController;
        private IController<MouseActions> mouseController;

        private SpriteAtlas linkAtlas;
        private Texture2D linkTexture;

        private SpriteFont creditsFont;
        private Color creditsColor;

        private List<ITextSprite> texts;

        private ISprite nonmovingNonanimatedSprite;
        private ISprite nonmovingAnimatedSprite;
        private ISprite movingNonanimatedSprite;
        private ISprite movingAnimatedSprite;

        private ISprite currentSprite;

        private ITextSprite creditsText;
        private ITextSprite nameText;
        private ITextSprite sourceText;

        private Vector2 spriteScale = new Vector2(4, 4);

        public Sprint0()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            IsMouseVisible = true;

            SetUpMouseController();
            SetUpKeyboardController();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            CreateSprites();
            CreateText();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            keyboardController.Update();
            mouseController.Update();

            currentSprite.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            currentSprite.Draw(spriteBatch);

            foreach (ITextSprite text in texts)
                text.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void SetUpMouseController()
        {
            mouseController = new MouseController();

            mouseController.RegisterCommand(MouseActions.Left, new SetSpriteMouseCommand(this));
            mouseController.RegisterCommand(MouseActions.Right, new ExitGameCommand(this));
        }

        private void SetUpKeyboardController()
        {
            keyboardController = new KeyboardController();

            keyboardController.RegisterCommand(Keys.D1, new SetNonmovingNonanimatedCommand(this));
            keyboardController.RegisterCommand(Keys.NumPad1, new SetNonmovingNonanimatedCommand(this));

            keyboardController.RegisterCommand(Keys.D2, new SetNonmovingAnimatedCommand(this));
            keyboardController.RegisterCommand(Keys.NumPad2, new SetNonmovingAnimatedCommand(this));

            keyboardController.RegisterCommand(Keys.D3, new SetMovingNonanimatedCommand(this));
            keyboardController.RegisterCommand(Keys.NumPad3, new SetMovingNonanimatedCommand(this));

            keyboardController.RegisterCommand(Keys.D4, new SetMovingAnimatedCommand(this));
            keyboardController.RegisterCommand(Keys.NumPad4, new SetMovingAnimatedCommand(this));

            keyboardController.RegisterCommand(Keys.D0, new ExitGameCommand(this));
            keyboardController.RegisterCommand(Keys.NumPad0, new ExitGameCommand(this));
        }

        private void CreateSprites()
        {
            linkTexture = Content.Load<Texture2D>("linkspritesheet");
            linkAtlas = new SpriteAtlas(linkTexture);

            nonmovingNonanimatedSprite = new FixedSprite(linkAtlas, new Vector2(400, 240), new Rectangle(306, 11, 16, 16), spriteScale);

            List<Rectangle> nonmovingAnimatedSource = new List<Rectangle> { new Rectangle(280, 77, 16, 16), new Rectangle(297, 77, 27, 16), new Rectangle(325, 77, 23, 16), new Rectangle(349, 77, 19, 16) };
            nonmovingAnimatedSprite = new AnimatedSprite(linkAtlas, new Vector2(368, 208), nonmovingAnimatedSource, .15f, spriteScale)
            {
                // Pivot shouldn't be centered as its source rectangles do not have constant size.
                CenterPivot = false
            };

            movingNonanimatedSprite = new CircleMoveSprite(linkAtlas, new Vector2(400, 240), new Rectangle(230, 11, 16, 16), 20, 2, spriteScale);

            List<Rectangle> movingAnimatedSource = new List<Rectangle> { new Rectangle(35, 11, 16, 16), new Rectangle(52, 11, 16, 16) };
            movingAnimatedSprite = new BackAndForthSprite(linkAtlas, new Vector2(400, 240), movingAnimatedSource, .2f, 20, 20, spriteScale);

            currentSprite = nonmovingNonanimatedSprite;
        }

        private void CreateText()
        {
            creditsFont = Content.Load<SpriteFont>("Credits");
            creditsColor = Color.AntiqueWhite;

            creditsText = new SimpleText("Credits", new Vector2(400, 400), creditsColor, creditsFont, true);
            nameText = new SimpleText("Made by: Austin Rogers.1274", new Vector2(400, 420), creditsColor, creditsFont, true);

            string sourceString = "Sprites from: https://www.spriters-resource.com/nes/legendofzelda/sheet/8366/";
            sourceText = new SimpleText(sourceString, new Vector2(400, 440), creditsColor, creditsFont, true);

            texts = new List<ITextSprite> { creditsText, nameText, sourceText };
        }

        public void SetNonmovingNonanimatedSprite()
        {
            currentSprite = nonmovingNonanimatedSprite;
        }

        public void SetNonmovingAnimatedSprite()
        {
            currentSprite = nonmovingAnimatedSprite;
        }

        public void SetMovingNonanimatedSprite()
        {
            currentSprite = movingNonanimatedSprite;
        }

        public void SetMovingAnimatedSprite()
        {
            currentSprite = movingAnimatedSprite;
        }
    }
}

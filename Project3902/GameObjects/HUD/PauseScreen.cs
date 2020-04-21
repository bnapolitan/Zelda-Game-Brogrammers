using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class PauseScreen
    {
        private FinalGame game;
        public List<IGameObject> PauseScreenElements = new List<IGameObject>();
        private HUDFactory Factory = HUDFactory.Instance;
        public static PauseScreen Instance { get; } = new PauseScreen();
        private PauseScreen()
        {
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(IGameObject obj in PauseScreenElements)
            {
                obj.Draw(spriteBatch);
            }
        }

        public void registerGame(FinalGame game)
        {
            this.game = game;
            createPauseElements();
        }

        private void createPauseElements()
        {
            PauseScreenElements.Add(Factory.createPauseInventorySection());
            PauseScreenElements.Add(Factory.createPauseMapSection());
        }
    }

    class StartMenuScreen
    {
        private FinalGame game;
        public List<IDrawable> ScreenElements = new List<IDrawable>();
        private HUDFactory Factory = HUDFactory.Instance;
        public static StartMenuScreen Instance { get; } = new StartMenuScreen();
        private StartMenuScreen()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IDrawable obj in ScreenElements)
            {
                obj.Draw(spriteBatch);
            }
        }

        public void registerGame(FinalGame game)
        {
            this.game = game;
            createElements();
        }

        private void createElements()
        {
            ScreenElements.Add(Factory.createStartSection(game.font, "Press N to start "));
            //ScreenElements.Add(Factory.createPauseMapSection());
        }
    }
    class GameOverScreen
    {
        private FinalGame game;
        public List<IDrawable> ScreenElements = new List<IDrawable>();
        private HUDFactory Factory = HUDFactory.Instance;
        public static GameOverScreen Instance { get; } = new GameOverScreen();
        private GameOverScreen()
        {
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IDrawable obj in ScreenElements)
            {
                obj.Draw(spriteBatch);
            }
        }

        public void registerGame(FinalGame game)
        {
            this.game = game;
            createElements();
        }

        private void createElements()
        {
            ScreenElements.Add(Factory.createStartSection(game.font, "Game Over!\nPress N to restart game "));
        }
    }
}

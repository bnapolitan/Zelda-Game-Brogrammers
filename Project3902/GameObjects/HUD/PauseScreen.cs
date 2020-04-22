using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project3902.ObjectManagement;

namespace Project3902
{
    class PauseScreen
    {
        private FinalGame game;
        private Vector2 PauseScale = new Vector2(4, 4);
        public List<IGameObject> PauseScreenElements = new List<IGameObject>();
        private readonly HUDFactory Factory = HUDFactory.Instance;
        public static PauseScreen Instance { get; } = new PauseScreen();
        private PauseScreen()
        {
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IGameObject obj in PauseScreenElements)
            {
                obj.Draw(spriteBatch);
            }
        }

        public void RegisterGame(FinalGame game)
        {
            this.game = game;
            CreatePauseElements();
        }

        public void CreatePauseElements()
        {
            PauseScreenElements.Add(Factory.CreatePauseInventorySection());
            PauseScreenElements.Add(Factory.CreatePauseMapSection());
            PauseScreenElements.Add(Factory.CreateBlackInventoryBox());
            PauseScreenElements.Add(Factory.CreateTopInventoryBlackBar());
            PauseScreenElements.Add(Factory.CreateItemBlackBox());
            PauseScreenElements.Add(Factory.CreateCompassBlackBox());
            var blackBox = Factory.CreateItemBlackBox();
            blackBox.Position = new Vector2(270, 210);
            PauseScreenElements.Add(blackBox);
        }



        public void AddMapToPauseScreen()
        {
            var createdObject = ItemFactory.Instance.CreateMap(new Vector2(180, 460));
            createdObject.Sprite.Scale = PauseScale;
            PauseScreenElements.Add(createdObject);

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

        public void RegisterGame(FinalGame game)
        {
            this.game = game;
            createElements();
        }

        private void createElements()
        {
            //ScreenElements.Add(EnvironmentFactory.Instance.CreateCoverScreen());
            ScreenElements.Add(Factory.createTextSection(game.font, "Press N to start "));

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

        public void RegisterGame(FinalGame game)
        {
            this.game = game;
            createElements();
        }

        private void createElements()
        {

            ScreenElements.Add(Factory.createTextSection(game.font, "Game Over!\nPress N to restart\n"));
        }
    }
}

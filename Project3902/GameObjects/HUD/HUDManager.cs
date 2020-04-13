
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project3902
{
    class HUDManager
    {
        private FinalGame game;
        public List<IGameObject> HUDElements = new List<IGameObject>();
        public List<IGameObject> HeartsList = new List<IGameObject>();
        public List<IGameObject> counterList = new List<IGameObject>();
        private readonly List<List<IGameObject>> numsLists = new List<List<IGameObject>>();
        private readonly HUDFactory Factory = HUDFactory.Instance;
        private IGameObject mapBlip;
        public static HUDManager Instance { get; } = new HUDManager();
        private int numHearts;
        private int maxHearts;
        public int numKeys = 0;
        public int numCoins = 0;
        public int numOrbs = 0;
        
        private HUDManager()
        {
        }

        public void Update()
        {
            numHearts = (int) game.Link.Health;
            maxHearts = (int) game.Link.MaxHealth;
            UpdateHearts();
            numKeys = game.Link.KeyCount;
            numOrbs = game.Link.PotionCount;
            numCoins = game.Link.CoinCount;
            UpdateCounters();
            if(blipCool != 0)
            {
                blipCool--;
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ShapeSpriteFactory.Instance.WhiteRect, new Rectangle(0, 0, (int) game.roomSize.X, HUDFactory.Instance.HUDHeight), Color.Black);

            foreach (IGameObject gameObject in HUDElements){
                gameObject.Draw(spriteBatch);
            }

            foreach(IGameObject gameObject in HeartsList)
            {
                gameObject.Draw(spriteBatch);
            }

            foreach(IGameObject gameObject in counterList)
            {
                gameObject.Draw(spriteBatch);
            }
            mapBlip.Draw(spriteBatch);
        }

        public void RegisterGame(FinalGame game)
        {
            this.game = game;
            AddBaseElements();
            CreateNumsLists();
        }

        private void AddBaseElements()
        {
            mapBlip = Factory.CreateMapBlip();
            HUDElements.Add(Factory.CreateLifeWord());
            HUDElements.Add(Factory.CreateCoinCountIcon());
            HUDElements.Add(Factory.CreateOrbCountIcon());
            HUDElements.Add(Factory.CreateKeyCountIcon());
            HUDElements.Add(Factory.CreateLevelWord());
            HUDElements.Add(Factory.CreateABox());
            HUDElements.Add(Factory.CreateBBox());
            HUDElements.Add(Factory.CreateOneCharacter());
            HUDElements.Add(Factory.CreateXCharacter());
            HUDElements.Add(Factory.CreateXCharacter());
            HUDElements.Add(Factory.CreateXCharacter());
            var blackBoxA = Factory.CreateItemBlackBox();
            blackBoxA.Sprite.Scale = Factory.HUDScale;
            blackBoxA.Position = new Vector2(315, 24);
            HUDElements.Add(blackBoxA);
            var blackBoxB = Factory.CreateItemBlackBox();
            blackBoxB.Sprite.Scale = Factory.HUDScale;
            blackBoxB.Position = new Vector2(395, 24);
            HUDElements.Add(blackBoxB);


            
        }

        private void UpdateHearts()
        {
            var heartsCreated = 0;

            HeartsList.Clear();
            while (heartsCreated + 2 <= numHearts)
            {
                var heart = Factory.CreateFullHeart();
                var tempPos = heart.Position;
                tempPos.X = heart.Position.X + (heartsCreated / 2) * 8 * heart.Sprite.Scale.X;
                heart.Position = tempPos;
                HeartsList.Add(heart);
                heartsCreated += 2;
            }
            if(numHearts%2 == 1)
            {
                var heart = Factory.CreateHalfHeart();
                var tempPos = heart.Position;
                tempPos.X = heart.Position.X + (heartsCreated / 2) * 8 * heart.Sprite.Scale.X;
                heart.Position = tempPos;
                HeartsList.Add(heart);
                heartsCreated += 2;
            }
            while(heartsCreated < maxHearts)
            {
                var heart = Factory.CreateEmptyHeart();
                var tempPos = heart.Position;
                tempPos.X = heart.Position.X + (heartsCreated / 2) * 8 * heart.Sprite.Scale.X;
                heart.Position = tempPos;
                HeartsList.Add(heart);
                heartsCreated += 2;
            }


        }

        private void CreateNumsLists()
        {
            numsLists.Add(Factory.CreateNumberList());
            numsLists.Add(Factory.CreateNumberList());
            numsLists.Add(Factory.CreateNumberList());
            numsLists.Add(Factory.CreateNumberList());
            numsLists.Add(Factory.CreateNumberList());
            numsLists.Add(Factory.CreateNumberList());
        }

        private void UpdateCounters()
        {
            var coinTen = numsLists[0][(numCoins % 100) / 10];
            var coinOne = numsLists[1][numCoins % 10];
            var keyTen = numsLists[2][(numKeys % 100) / 10];
            var keyOne = numsLists[3][numKeys % 10];
            var orbTen = numsLists[4][(numOrbs % 100) / 10];
            var orbOne = numsLists[5][numOrbs % 10];
            coinTen.Position = new Vector2(551,8);
            coinOne.Position = new Vector2(575,8);
            keyTen.Position = new Vector2(551,37);
            keyOne.Position = new Vector2(575,37);
            orbTen.Position = new Vector2(551,66);
            orbOne.Position = new Vector2(575,66);
            counterList.Add(coinTen);
            counterList.Add(coinOne);
            counterList.Add(keyTen);
            counterList.Add(keyOne);
            counterList.Add(orbTen);
            counterList.Add(orbOne);
        }

        public void MoveMapBlipUp()
        {
            if (blipCool == 0)
            { 
                var tempPos = mapBlip.Position;
                tempPos.Y -= 12;
                mapBlip.Position = tempPos;
               
                blipCool = 10;
            }
            
            

        }
        private int blipCool = 0;
        public void MoveMapBlipLeft()
        {
            if (blipCool == 0)
            {
                var tempPos = mapBlip.Position;
                tempPos.X -= 18;
                mapBlip.Position = tempPos;
                blipCool = 10;
            }


        }

        public void MoveMapBlipRight()
        {
            if (blipCool == 0)
            {


                var tempPos = mapBlip.Position;
                tempPos.X += 18;
                mapBlip.Position = tempPos;
                blipCool = 10;
            }
        }

        public void MoveMapBlipDown()
        {
            if (blipCool == 0)
            {
                var tempPos = mapBlip.Position;
                tempPos.Y += 12;
                mapBlip.Position = tempPos;
                blipCool = 10;
            }
        }

        public void AddMapToHUD()
        {
            var levelMap = Factory.CreateLevelMap();
            foreach (IGameObject hudElement in levelMap)
            {
                HUDElements.Add(hudElement);
            }
        }


    }
}

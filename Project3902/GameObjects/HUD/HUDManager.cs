
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3902
{
    class HUDManager
    {
        private FinalGame game;
        public List<IGameObject> HUDElements = new List<IGameObject>();
        public List<IGameObject> HeartsList = new List<IGameObject>();
        public List<IGameObject> counterList = new List<IGameObject>();
        private List<List<IGameObject>> numsLists = new List<List<IGameObject>>();
        private HUDFactory Factory = HUDFactory.Instance;
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
            updateHearts();
            numKeys = game.Link.KeyCount;
            numOrbs = game.Link.PotionCount;
            numCoins = game.Link.CoinCount;
            updateCounters();
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
            Factory.createMapBlock().Draw(spriteBatch);
        }

        public void registerGame(FinalGame game)
        {
            this.game = game;
            addBaseElements();
            createNumsLists();
        }

        private void addBaseElements()
        {
            HUDElements.Add(Factory.createMapBlip());
            HUDElements.Add(Factory.createLifeWord());
            HUDElements.Add(Factory.createCoinCountIcon());
            HUDElements.Add(Factory.createOrbCountIcon());
            HUDElements.Add(Factory.createKeyCountIcon());
            HUDElements.Add(Factory.createLevelWord());
            HUDElements.Add(Factory.createABox());
            HUDElements.Add(Factory.createBBox());
            HUDElements.Add(Factory.createOneCharacter());
            HUDElements.Add(Factory.createXCharacter());
            HUDElements.Add(Factory.createXCharacter());
            HUDElements.Add(Factory.createXCharacter());
        }

        private void updateHearts()
        {
            var heartsCreated = 0;

            HeartsList.Clear();
            while (heartsCreated + 2 <= numHearts)
            {
                var heart = Factory.createFullHeart();
                var tempPos = heart.Position;
                tempPos.X = heart.Position.X + (heartsCreated / 2) * 8 * heart.Sprite.Scale.X;
                heart.Position = tempPos;
                HeartsList.Add(heart);
                heartsCreated += 2;
            }
            if(numHearts%2 == 1)
            {
                var heart = Factory.createHalfHeart();
                var tempPos = heart.Position;
                tempPos.X = heart.Position.X + (heartsCreated / 2) * 8 * heart.Sprite.Scale.X;
                heart.Position = tempPos;
                HeartsList.Add(heart);
                heartsCreated += 2;
            }
            while(heartsCreated < maxHearts)
            {
                var heart = Factory.createEmptyHeart();
                var tempPos = heart.Position;
                tempPos.X = heart.Position.X + (heartsCreated / 2) * 8 * heart.Sprite.Scale.X;
                heart.Position = tempPos;
                HeartsList.Add(heart);
                heartsCreated += 2;
            }

            
        }

        private void createNumsLists()
        {
            numsLists.Add(Factory.createNumberList());
            numsLists.Add(Factory.createNumberList());
            numsLists.Add(Factory.createNumberList());
            numsLists.Add(Factory.createNumberList());
            numsLists.Add(Factory.createNumberList());
            numsLists.Add(Factory.createNumberList());
        }

        private void updateCounters()
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

        public void moveMapBlipUp()
        {
            if (blipCool == 0)
            { 
                var tempPos = HUDElements[0].Position;
                tempPos.Y -= 12;
                HUDElements[0].Position = tempPos;
               
                blipCool = 10;
            }
            
            

        }
        private int blipCool = 0;
        public void moveMapBlipLeft()
        {
            if (blipCool == 0)
            {
                var tempPos = HUDElements[0].Position;
                tempPos.X -= 21;
                HUDElements[0].Position = tempPos;
                blipCool = 10;
            }


        }

        public void moveMapBlipRight()
        {
            if (blipCool == 0)
            {


                var tempPos = HUDElements[0].Position;
                tempPos.X += 21;
                HUDElements[0].Position = tempPos;
                blipCool = 10;
            }
        }

        public void moveMapBlipDown()
        {
            if (blipCool == 0)
            {
                var tempPos = HUDElements[0].Position;
                tempPos.Y += 12;
                HUDElements[0].Position = tempPos;
                blipCool = 10;
            }
        }


    }
}

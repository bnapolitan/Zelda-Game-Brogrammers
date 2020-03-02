using Microsoft.Xna.Framework;
using Project3902.LevelBuilding;
using Project3902.LevelBuilding.Interface;
using Project3902.ObjectManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Project3902
{
    class LevelBuilder : ILevel
    {
        public FinalGame Game { get; }
        private readonly string levelName;
        private readonly EnvironmentFactory envFactory = EnvironmentFactory.Instance;
        private readonly ObjectLookup objectLookup = new ObjectLookup();

        public LevelBuilder(FinalGame game, string levelName)
        {
            Game = game;
            this.levelName = levelName;
        }

        public List<IGameObject> CreateInteractiveEnvironmentObjects()
        {
            var environmentObjects = new List<IGameObject>();
            environmentObjects.Add(envFactory.CreateRoomBorder(new Vector2(0, 0)));

            for (int j = 128; j < 560; j += 64)
            {
                for (int i = 128; i < 839; i += 64)
                {
                    environmentObjects.Add(envFactory.CreateFloorTile(new Vector2(i, j)));
                }
            }

            var csvReader = new StreamReader($"../../../../LevelBuilding/Levels/{levelName}.csv");
            
            if(csvReader.ReadLine() != "Environment")
            {
                return environmentObjects;
            }

            while (!csvReader.EndOfStream)
            {
                var line = csvReader.ReadLine();
                var values = line.Split(',');

                if(values[0] == "Enemies")
                {
                    break;
                }

                var position = new Vector2(float.Parse(values[1]), float.Parse(values[2]));

                environmentObjects.Add(objectLookup.CreateEnvironmentObject(values[0], position));
            }

            csvReader.Close();

            return environmentObjects;
        }

        public List<IGameObject> CreateEnemyObjects()
        {
            var enemyObjects = new List<IGameObject>();

            var csvReader = new StreamReader($"../../../../LevelBuilding/Levels/{levelName}.csv");

            while(csvReader.ReadLine() != "Enemies")
            {
                if(csvReader.EndOfStream)
                {
                    return enemyObjects;
                }
            }

            while (!csvReader.EndOfStream)
            {
                var line = csvReader.ReadLine();
                var values = line.Split(',');

                var position = new Vector2(float.Parse(values[1]), float.Parse(values[2]));

                enemyObjects.Add(objectLookup.CreateEnemyObject(values[0], position));
            }

            csvReader.Close();

            return enemyObjects;
        }

    }
}
